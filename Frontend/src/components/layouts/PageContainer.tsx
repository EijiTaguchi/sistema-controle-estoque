import type { ReactNode } from "react";


type Props = {
  children: ReactNode;
};

export function PageContainer({
  children,
}: Props) {
  return (
    <main className="flex-1 p-6">
      {children}
    </main>
  );
}