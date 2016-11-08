using System;
using System.Net;
using System.Net.Sockets;

namespace FTPClient
{
    class MainClass
    {
        /**
         * <summary>Main method</summary>
         * <param name="args">Command line arguments</param>
         */
        public static void Main( string[] args )
        {
            if ( args.Length == 0 )
                usage();

            string server = args[0];
            try {
                // TODO: Connect to server

                // Get the object used to communicate with the server.
                var request = new WebClient();
                var read = request.OpenRead( server );
                byte[] output = new byte[10000];
                read.Read( output, 0, 10000 );
                Console.WriteLine( output );





                var write = request.OpenWrite( server );

                var command = "USER NAME";
                byte[] bytes = new byte[command.Length * sizeof( char )];
                System.Buffer.BlockCopy( command.ToCharArray(), 0, bytes, 0, bytes.Length );

                write.Write( bytes, 0, 9 );
                write.Flush();
               

              

                // This example assumes the FTP site uses anonymous logon.
                //request.Credentials = new NetworkCredential ("anonymous","");
                try {
                    //byte[] newFileData = request.DownloadData( "" );
                    //string fileString = System.Text.Encoding.UTF8.GetString( newFileData );
                    //Console.WriteLine( fileString );
                } catch ( WebException e ) {
                    Console.WriteLine( e );
                }

            } catch ( Exception ex ) {
                // TODO: Connection problem message
                Console.WriteLine( ex );
            }

            while ( true ) {
                Console.Write( "ftp> " );
                string token = Console.ReadLine();

                switch (token) {
                    case "ascii":
                        break;
                    case "binary":
                        break;
                    case "cd":
                        break;
                    case "cdup":
                        break;
                    case "debug":
                        break;
                    case "dir":
                        break;
                    case "get":
                        break;
                    case "help":
                        help();
                        break;
                    case "passive":
                        break;
                    case "pwd":
                        break;
                    case "quit":
                        return;
                    default:
                        Console.WriteLine( "Unknown command. Supported commands:" );
                        help();
                        break;
                }
            }
        }

        /**
         * <summary>Display the supported commands to the console.</summary>
         */
        private static void help()
        {
            Console.WriteLine( "  {0, -15} {1, -60}", "ascii", "Set ASCII transfer type" );
            Console.WriteLine( "  {0, -15} {1, -60}", "binary", "Set binary transfer type" );
            Console.WriteLine( "  {0, -15} {1, -60}", "cd <path>", "Change remote working directory" );
            Console.WriteLine( "  {0, -15} {1, -60}", "cdup", "Change remote working directory to parent directory" );
            Console.WriteLine( "  {0, -15} {1, -60}", "debug", "Toggle debugging mode" );
            Console.WriteLine( "  {0, -15} {1, -60}", "dir", "List the contents of the remote directory" );
            Console.WriteLine( "  {0, -15} {1, -60}", "get <filename>", "Retrieve a file from the remote system" );
            Console.WriteLine( "  {0, -15} {1, -60}", "help", "Provide help for each command implemented by the client" );
            Console.WriteLine( "  {0, -15} {1, -60}", "passive", "Toggle passive/active transfer mode" );
            Console.WriteLine( "  {0, -15} {1, -60}", "pwd", "Print the working directory on the server" );
            Console.WriteLine( "  {0, -15} {1, -60}", "quit", "Close the connection to the server and terminate the program" );
        }

        /**
         * <summary>Display a usage message to the console and exit.</summary>
         */
        private static void usage()
        {
            Console.WriteLine( "Usage: FTP <ServerName>" );
            Environment.Exit( 1 );
        }
    }
}
