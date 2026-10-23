with Ada.Real_Time;

package body Logger is
   Start_Time : constant Time := Clock;

   function Time_Stamp return String is
      Now : constant Time := Clock;
      Elapsed : constant Time_Span := Now - Start_Time;
      Total_Tenths : constant Integer := Integer(To_Duration(Elapsed) * Duration(10.0) + Duration(0.5));
      Minutes : constant Integer := Total_Tenths / 600;
      Seconds : constant Integer := (Total_Tenths / 10) mod 60;
      Tenths : constant Integer := Total_Tenths mod 10;
      M1 : constant Character := Character'Val(Character'Pos('0') + (Minutes / 10));
      M2 : constant Character := Character'Val(Character'Pos('0') + (Minutes mod 10));
      S1 : constant Character := Character'Val(Character'Pos('0') + (Seconds / 10));
      S2 : constant Character := Character'Val(Character'Pos('0') + (Seconds mod 10));
      T1 : constant Character := Character'Val(Character'Pos('0') + Tenths);
   begin
      return "[" & M1 & M2 & ":" & S1 & S2 & "." & T1 & "]" & " ";
   end Time_Stamp;
end Logger;
