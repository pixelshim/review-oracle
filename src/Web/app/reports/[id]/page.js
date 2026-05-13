import { getReportById } from '../../../lib/apiClient';

export default async function ReportDetailPage({ params }) {
  try {
    const report = await getReportById(params.id);

    return (
      <main>
        <h1>{report.title}</h1>
        <p>{report.summary}</p>
      </main>
    );
  } catch {
    return (
      <main>
        <h1>Report not found</h1>
      </main>
    );
  }
}
