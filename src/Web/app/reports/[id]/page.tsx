import { fetchReport } from "@/lib/api";

export default async function ReportDetailPage({ params }: { params: { id: string } }) {
  try {
    const report = await fetchReport(params.id);
    return (
      <main>
        <h1>{report.title}</h1>
        <p>{report.summary}</p>
      </main>
    );
  } catch {
    return <p>Unable to load report.</p>;
  }
}
