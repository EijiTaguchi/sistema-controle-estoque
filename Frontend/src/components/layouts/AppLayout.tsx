import { Outlet } from "react-router-dom";
import { Sidebar } from "./Sidebar";
import { Navbar } from "./Navbar";

export default function AppLayout() {
  return (
    <div className="flex min-h-screen">

      <Sidebar />

      <div className="flex flex-1 flex-col">

        <Navbar />
        <main className="flex-1 bg-muted/20 p-6">
          <Outlet />
        </main>
      </div>
    </div>
  );
}