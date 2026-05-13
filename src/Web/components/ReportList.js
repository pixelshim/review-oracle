'use client';

import Link from 'next/link';

export default function ReportList({ reports }) {
  return (
    <ul>
      {reports.map((report) => (
        <li key={report.id}>
          <Link href={`/reports/${report.id}`}>{report.title}</Link>
        </li>
      ))}
    </ul>
  );
}
