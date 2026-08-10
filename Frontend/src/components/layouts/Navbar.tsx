import { Bell } from "lucide-react";
import { UserMenu } from "./UserMenu";
import { Button } from "../ui/button";

export function Navbar() {
  return (
    <header className="flex h-16 items-center justify-end border-b px-6">
      <div className="flex items-center gap-4">
        <Button
          variant="ghost"
          size="icon"
        >
          <Bell />
        </Button>

        <UserMenu />
      </div>
    </header>
  );
}