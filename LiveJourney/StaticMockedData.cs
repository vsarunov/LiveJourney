using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourney
{
    public static class StaticTrainLinesAndStations
    {
        public static Dictionary<string, string> TrainLinesAndStations = new Dictionary<string, string>();
        public static void PopulateTrainLines()
        {
            TrainLinesAndStations.Add("Bakerloo", @"Elephant And Castle
Lambeth North
Waterloo
Embankment
Charing Cross
Piccadilly Circus
Oxford Circus
Regent’s Park
Baker Street
Marylebone
Edgware Road
Paddington
Warwick Avenue
Maida Vale
Kilburn Park
Queen’s Park
Kensal Green
Willesden Junction
Harlesden
Stonebridge Park
Wembley Central
North Wembley
South Kenton
Kenton
Harrow And Wealdstone");

            TrainLinesAndStations.Add("Central", @"Epping
Theydon Bois
Debden
Loughton
Buckhurst Hill
Woodford
South Woodford
Snaresbrook
Leytonstone
Leyton
Stratford
Mile End
Bethnal Green
Liverpool Street
Bank
St. Paul’s
Chancery Lane
Holborn
Tottenham Court Road
Oxford Circus
Bond Street
Marble Arch
Lancaster Gate
Queensway
Notting Hill Gate
Holland Park
Shepherd’s Bush
White City
East Acton
North Acton
West Acton
Ealing Broadway");

            TrainLinesAndStations.Add("Circle", @"Aldgate
Tower Hill
Monument
Cannon Street
Mansion House
Blackfriars
Temple
Embankment
Westminster
St. James’ Park
Victoria
Sloane Square
South Kensington
Gloucester Road
High Street Kensington
Notting Hill Gate
Bayswater
Paddington
Edgware Road
Baker Street
Great Portland Street
Euston Square
King’s Cross St. Pancras
Farringdon
Barbican
Moorgate
Liverpool Street");

            TrainLinesAndStations.Add("District", @"Upminster
Upminster Bridge
Hornchurch
Elm Park
Dagenham East
Dagenham Heathway
Becontree
Upney
Barking
East Ham
Upton Park
Plaistow
West Ham
Bromley-By-Bow
Bow Road
Mile End
Stepney Green
Whitechapel
Aldgate East
Tower Hill
Monument
Cannon Street
Mansion House
Blackfriars
Temple
Embankment
Westminster
St. James Park
Victoria
Sloane Square
South Kensington
Gloucester Road
Earl’s Court
West Kensington
Barons Court
Hammersmith
Ravenscourt Park
Stamford Brook
Turnham Green
Gunnersbury
Kew Gardens
Richmond");

            TrainLinesAndStations.Add("Hammersmith & City", @"Barking
East Ham
Upton Park
West Ham
Bromley-By-Bow
Bow Road
Mile End
Stepney Green
Whitechapel
Aldgate East
Liverpool Street
Moorgate
Barbican
Farringdon
King’s Cross St. Pancras
Euston Square
Great Portland Street
Baker Street
Edgware Road
Paddington
Royal Oak
Westbourne Park
Ladbroke Grove
Latimer Road
Wood Lane
Shepherd’s Bush Market
Goldhawk Road
Hammersmith");

            TrainLinesAndStations.Add("Jubilee", @"Stanmore
Canons Park
Queensbury
Kingsbury
Wembley Park
Neasden
Dollis Hill
Willesden Green
Kilburn
West Hampstead
Finchley Road
Swiss Cottage
St. John’s Wood
Baker Street
Bond Street
Green Park
Westminster
Waterloo
Southwark
London Bridge
Bermondsey
Canada Water
Canary Wharf
North Greenwich
Canning Town
West Ham
Stratford");

            TrainLinesAndStations.Add("Metropolitan", @"Aldgate
Liverpool Street
Moorgate
Barbican
Farringdon
King’s Cross. St Pancras
Euston Square
Great Portland Street
Baker Street
Finchley Road
Wembley Park
Preston Road
Northwick Park
Harrow-On-The-Hill
North Harrow
Pinner
Northwood Hills
Northwood
Moor Park
Croxley
Watford");

            TrainLinesAndStations.Add("Northern", @"Morden
South Wimbledon
Colliers Wood
Tooting Broadway
Tooting Bec
Balham
Clapham South
Clapham Common
Clapham North
Stockwell
Oval
Kennington
Waterloo
Embankment
Charing Cross
Leicester Square
Tottenham Court Road
Goodge Street
Warren Street
Euston
Mornington Crescent
Camden Town
Chalk Farm
Belsize Park
Hampstead
Golders Green
Brent Cross
Hendon Central
Colindale
Burnt Oak
Edgware");

            TrainLinesAndStations.Add("Piccadilly", @"Cockfosters
Oakwood
Southgate
Arnos Grove
Bounds Green
Wood Green
Turnpike Lane
Manor House
Finsbury Park
Arsenal
Holloway Road
Caledonian Road
King’s Cross St. Pancras
Russell Square
Holborn
Covent Garden
Leicester Square
Piccadilly Circus
Green Park
Hyde Park Corner
Knightsbridge
South Kensington
Gloucester Road
Earl’s Court
Barons Court
Hammersmith
Turnham Green
Acton Town
Ealing Common
North Ealing
Royal Park
Alperton
Sudbury Town
Sudbury Hill
South Harrow
Rayners Lane
Eastcote
Ruislip Manor
Ruislip
Ickenham
Hillingdon
Uxbridge");

            TrainLinesAndStations.Add("Victoria", @"Walthamstow Central
Blackhorse Road
Tottenham Hale
Seven Sisters
Finsbury Park
Highbury & Islington
King’s Cross St. Pancras
Euston
Warren Street
Oxford Circus
Green Park
Victoria
Pimlico
Vauxhall
Stockwell
Brixton");
        }
    }
}
