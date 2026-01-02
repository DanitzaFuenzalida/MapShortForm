import csv
from pathlib import Path

INPUT = Path('data.csv')
OUTPUT = Path('data_values.sql')
TABLE = 'locations'
COLUMNS = ['address', 'city', 'lat', 'lng']

def escape_sql(s: str) -> str:
    return s.replace("'", "''")

def main():
    rows = []
    with INPUT.open('r', encoding='utf-8') as f:
        reader = csv.reader(f, delimiter='\t')
        for r in reader:
            if not r:
                continue
            # tolerate lines with extra whitespace
            r = [c.strip() for c in r]
            if len(r) < 4:
                continue
            rows.append(r[:4])

    values = []
    for a, b, lat, lng in rows:
        a_esc = escape_sql(a)
        b_esc = escape_sql(b)
        try:
            lat_f = float(lat)
        except Exception:
            lat_f = None
        try:
            lng_f = float(lng)
        except Exception:
            lng_f = None

        lat_val = 'NULL' if lat_f is None else repr(lat_f)
        lng_val = 'NULL' if lng_f is None else repr(lng_f)

        values.append(f"('{a_esc}','{b_esc}',{lat_val},{lng_val})")

    with OUTPUT.open('w', encoding='utf-8', newline='') as f:
        f.write(f"INSERT INTO {TABLE} ({', '.join(COLUMNS)}) VALUES\n")
        f.write(',\n'.join(values))
        f.write(';\n')

    print(f'Wrote {len(values)} rows to {OUTPUT}')

if __name__ == '__main__':
    main()
