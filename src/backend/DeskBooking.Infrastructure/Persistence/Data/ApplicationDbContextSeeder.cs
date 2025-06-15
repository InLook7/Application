using DeskBooking.Domain.Entities;

namespace DeskBooking.Infrastructure.Persistence.Data;

public class ApplicationDbContextSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        bool IsSeedingRequired = context.WorkspaceTypes.Any();

        if (!IsSeedingRequired)
        {
            await SeedCoworkingsAsync(context);
            await SeedCoworkingPhotosAsync(context);
            await SeedWorkspaceTypesAsync(context);
            await SeedWorkspacePhotosAsync(context);
            await SeedAmenitiesAsync(context);
            await SeedWorkspaceTypeAmenitiesAsync(context);
            await SeedWorkspacesAsync(context);
        }
    }

    private static async Task SeedCoworkingsAsync(ApplicationDbContext context)
    {
        context.Coworkings.AddRange(
            new Coworking
            {
                Name = "WorkClub Pechersk",
                Description = "Modern coworking in the heart of Pechersk with " +
                    "quiet rooms and coffee on tap.",
                Address = "123 Yaroslaviv Val St, Kyiv"
            },
            new Coworking
            {
                Name = "UrbanSpace Podil",
                Description = "A creative riverside hub ideal for freelancers " +
                    "and small startups.",
                Address = "78 Naberezhno-Khreshchatytska St, Kyiv"
            },
            new Coworking
            {
                Name = "Creative Hub Lvivska",
                Description = "A compact, design-focused space with " +
                    "open desks and strong community vibes.",
                Address = "12 Lvivska Square, Kyiv"
            },
            new Coworking
            {
                Name = "TechNest Olimpiiska",
                Description = "A high-tech space near Olimpiiska metro, " +
                    "perfect for team sprints and solo focus.",
                Address = "45 Velyka Vasylkivska St, Kyiv"
            },
            new Coworking
            {
                Name = "Hive Station Troieshchyna",
                Description = "A quiet, affordable option in the city's " +
                    "northeast - great for remote workers.",
                Address = "102 Zakrevskogo St, Kyiv"
            }
        );

        await context.SaveChangesAsync();
    }
    
    private static async Task SeedCoworkingPhotosAsync(ApplicationDbContext context)
    {
        context.CoworkingPhotos.AddRange(
            new CoworkingPhoto
            {
                CoworkingId = 1,
                Title = "View",
                FilePath = "images/coworkings/workclub-pechersk.jpg"
            },
            new CoworkingPhoto
            {
                CoworkingId = 2,
                Title = "View",
                FilePath = "images/coworkings/urbanspace-podil.jpg"
            },
            new CoworkingPhoto
            {
                CoworkingId = 3,
                Title = "View",
                FilePath = "images/coworkings/creative-hub-lvivska.jpg"
            },
            new CoworkingPhoto
            {
                CoworkingId = 4,
                Title = "View",
                FilePath = "images/coworkings/technest-olimpiiska.jpg"
            },
            new CoworkingPhoto
            {
                CoworkingId = 5,
                Title = "View",
                FilePath = "images/coworkings/hive-station-troieshchyna.jpg"
            }
        );

        await context.SaveChangesAsync();
    }

    private static async Task SeedWorkspaceTypesAsync(ApplicationDbContext context)
    {
        context.WorkspaceTypes.AddRange(
            new WorkspaceType
            {
                Name = "Open Space",
                Description = "A vibrant shared area perfect for freelancers or small teams " +
                    "who enjoy a collaborative atmosphere. Choose any available desk " +
                    "and get to work with flexibility and ease."
            },
            new WorkspaceType
            {
                Name = "Private Room",
                Description = "Ideal for focused work, video calls, or small team huddles. " +
                    "These fully enclosed rooms offer privacy and come in a variety " +
                    "of sizes to fit your needs."
            },
            new WorkspaceType
            {
                Name = "Meeting Room",
                Description = "Designed for productive meetings, workshops, or client " +
                    "presentations. Equipped with screens, whiteboards, and " +
                    "comfortable seating to keep your sessions running smoothly."
            }
        );

        await context.SaveChangesAsync();
    }

    private static async Task SeedWorkspacePhotosAsync(ApplicationDbContext context)
    {
        context.WorkspacePhotos.AddRange(
            new WorkspacePhoto
            {
                WorkspaceTypeId = 1,
                Title = "View 1",
                FilePath = "images/open-spaces/open-space1.jpg"
            },
            new WorkspacePhoto
            {
                WorkspaceTypeId = 1,
                Title = "View 2",
                FilePath = "images/open-spaces/open-space2.jpg"
            },
            new WorkspacePhoto
            {
                WorkspaceTypeId = 1,
                Title = "View 3",
                FilePath = "images/open-spaces/open-space3.jpg"
            },
            new WorkspacePhoto
            {
                WorkspaceTypeId = 2,
                Title = "View 1",
                FilePath = "images/private-rooms/private-room1.jpg"
            },
            new WorkspacePhoto
            {
                WorkspaceTypeId = 2,
                Title = "View 2",
                FilePath = "images/private-rooms/private-room2.jpg"
            },
            new WorkspacePhoto
            {
                WorkspaceTypeId = 2,
                Title = "View 3",
                FilePath = "images/private-rooms/private-room3.jpg"
            },
            new WorkspacePhoto
            {
                WorkspaceTypeId = 3,
                Title = "View 1",
                FilePath = "images/meeting-rooms/meeting-room1.jpg"
            },
            new WorkspacePhoto
            {
                WorkspaceTypeId = 3,
                Title = "View 2",
                FilePath = "images/meeting-rooms/meeting-room2.jpg"
            },
            new WorkspacePhoto
            {
                WorkspaceTypeId = 3,
                Title = "View 3",
                FilePath = "images/meeting-rooms/meeting-room3.jpg"
            }
        );

        await context.SaveChangesAsync();
    }

    private static async Task SeedAmenitiesAsync(ApplicationDbContext context)
    {
        context.Amenities.AddRange(
            new Amenity { Name = "Screen", FilePath = "images/amenities/screen.jpg" },
            new Amenity { Name = "Microphone", FilePath = "images/amenities/microphone.jpg" },
            new Amenity { Name = "Headphones", FilePath = "images/amenities/headphones.jpg" },
            new Amenity { Name = "Wifi", FilePath = "images/amenities/wifi.jpg" },
            new Amenity { Name = "Coffee", FilePath = "images/amenities/coffee.jpg" },
            new Amenity { Name = "Gaming", FilePath = "images/amenities/gaming.jpg" }
        );

        await context.SaveChangesAsync();
    }

    private static async Task SeedWorkspaceTypeAmenitiesAsync(ApplicationDbContext context)
    {
        context.WorkspaceTypeAmenities.AddRange(
            new WorkspaceTypeAmenity { WorkspaceTypeId = 1, AmenityId = 1 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 1, AmenityId = 4 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 1, AmenityId = 5 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 1, AmenityId = 6 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 2, AmenityId = 1 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 2, AmenityId = 2 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 2, AmenityId = 4 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 3, AmenityId = 1 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 3, AmenityId = 2 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 3, AmenityId = 3 },
            new WorkspaceTypeAmenity { WorkspaceTypeId = 3, AmenityId = 4 }
        );

        await context.SaveChangesAsync();
    }

    private static async Task SeedWorkspacesAsync(ApplicationDbContext context)
    {
        context.Workspaces.AddRange(
            new Workspace
            {
                Name = "Compact Desk 1",
                CoworkingId = 1,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 11
            },
            new Workspace
            {
                Name = "Compact Desk 2",
                CoworkingId = 1,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 11
            },
            new Workspace
            {
                Name = "Compact Desk 3",
                CoworkingId = 1,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 11
            },
            new Workspace
            {
                Name = "Mid Desk 1",
                CoworkingId = 2,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Mid Desk 2",
                CoworkingId = 2,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Mid Desk 3",
                CoworkingId = 2,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Cozy Desk 1",
                CoworkingId = 3,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Cozy Desk 2",
                CoworkingId = 3,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Cozy Desk 3",
                CoworkingId = 3,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Vast Desk 1",
                CoworkingId = 4,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 3
            },
            new Workspace
            {
                Name = "Vast Desk 2",
                CoworkingId = 4,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 3
            },
            new Workspace
            {
                Name = "Vast Desk 3",
                CoworkingId = 4,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 3
            },
            new Workspace
            {
                Name = "Elite Desk 1",
                CoworkingId = 5,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 2
            },
            new Workspace
            {
                Name = "Elite Desk 2",
                CoworkingId = 5,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 2
            },
            new Workspace
            {
                Name = "Elite Desk 3",
                CoworkingId = 5,
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 2
            },
            new Workspace
            {
                Name = "Solo Private Room 1",
                CoworkingId = 1,
                WorkspaceTypeId = 2,
                Capacity = 1,
                Quantity = 8
            },
            new Workspace
            {
                Name = "Solo Private Room 2",
                CoworkingId = 2,
                WorkspaceTypeId = 2,
                Capacity = 1,
                Quantity = 8
            },
            new Workspace
            {
                Name = "Solo Private Room 3",
                CoworkingId = 3,
                WorkspaceTypeId = 2,
                Capacity = 1,
                Quantity = 8
            },
            new Workspace
            {
                Name = "Solo Private Room 4",
                CoworkingId = 4,
                WorkspaceTypeId = 2,
                Capacity = 1,
                Quantity = 8
            },
            new Workspace
            {
                Name = "Solo Private Room 5",
                CoworkingId = 5,
                WorkspaceTypeId = 2,
                Capacity = 1,
                Quantity = 8
            },
            new Workspace
            {
                Name = "Duo Private Room 1",
                CoworkingId = 1,
                WorkspaceTypeId = 2,
                Capacity = 2,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Duo Private Room 2",
                CoworkingId = 2,
                WorkspaceTypeId = 2,
                Capacity = 2,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Duo Private Room 3",
                CoworkingId = 3,
                WorkspaceTypeId = 2,
                Capacity = 2,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Duo Private Room 4",
                CoworkingId = 4,
                WorkspaceTypeId = 2,
                Capacity = 2,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Duo Private Room 5",
                CoworkingId = 5,
                WorkspaceTypeId = 2,
                Capacity = 2,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Team Private Room 1",
                CoworkingId = 1,
                WorkspaceTypeId = 2,
                Capacity = 5,
                Quantity = 3
            },
            new Workspace
            {
                Name = "Team Private Room 2",
                CoworkingId = 4,
                WorkspaceTypeId = 2,
                Capacity = 5,
                Quantity = 3
            },
            new Workspace
            {
                Name = "Collaboration Private Room",
                CoworkingId = 1,
                WorkspaceTypeId = 2,
                Capacity = 10,
                Quantity = 1
            },
            new Workspace
            {
                Name = "Conference Meeting Room 1",
                CoworkingId = 1,
                WorkspaceTypeId = 3,
                Capacity = 10,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Conference Meeting Room 2",
                CoworkingId = 2,
                WorkspaceTypeId = 3,
                Capacity = 10,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Conference Meeting Room 3",
                CoworkingId = 3,
                WorkspaceTypeId = 3,
                Capacity = 10,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Conference Meeting Room 4",
                CoworkingId = 4,
                WorkspaceTypeId = 3,
                Capacity = 10,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Conference Meeting Room 5",
                CoworkingId = 5,
                WorkspaceTypeId = 3,
                Capacity = 10,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Big Conference Meeting Room 1",
                CoworkingId = 1,
                WorkspaceTypeId = 3,
                Capacity = 20,
                Quantity = 1
            },
            new Workspace
            {
                Name = "Big Conference Meeting Room 2",
                CoworkingId = 2,
                WorkspaceTypeId = 3,
                Capacity = 20,
                Quantity = 1
            },
            new Workspace
            {
                Name = "Big Conference Meeting Room 3",
                CoworkingId = 3,
                WorkspaceTypeId = 3,
                Capacity = 20,
                Quantity = 1
            },
            new Workspace
            {
                Name = "Big Conference Meeting Room 4",
                CoworkingId = 4,
                WorkspaceTypeId = 3,
                Capacity = 20,
                Quantity = 1
            },
            new Workspace
            {
                Name = "Big Conference Meeting Room 5",
                CoworkingId = 5,
                WorkspaceTypeId = 3,
                Capacity = 20,
                Quantity = 1
            }
        );
        
        await context.SaveChangesAsync();
    }
}