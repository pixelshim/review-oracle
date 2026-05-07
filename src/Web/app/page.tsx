import Link from "next/link";
import { AuthButtons } from "@/components/AuthButtons";
import { fetchReports } from "@/lib/api";

export default async function HomePage() {
  const reports = await fetchReports();

  return (
    <main>
      <h1>Review Oracle</h1>
      <AuthButtons />
      <h2>Reports</h2>
      <ul>
        {reports.map((report) => (
          <li key={report.id}>
            <Link href={`/reports/${report.id}`}>{report.title}</Link>
          </li>
        ))}
      </ul>
    </main>
  );
}
