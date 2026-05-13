import { getReports } from '../lib/apiClient';
import ReportList from '../components/ReportList';

export default async function HomePage() {
  try {
    const reports = await getReports();

    return (
      <main>
        <h1>Reports</h1>
        <ReportList reports={reports} />
      </main>
    );
  } catch (error) {
    return (
      <main>
        <h1>Reports</h1>
        <p>Unable to load reports right now.</p>
      </main>
    );
  }
}
