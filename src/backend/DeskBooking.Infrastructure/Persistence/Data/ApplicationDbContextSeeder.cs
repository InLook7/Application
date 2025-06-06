using DeskBooking.Domain.Entities;

namespace DeskBooking.Infrastructure.Persistence.Data;

public class ApplicationDbContextSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        bool IsSeedingRequired = context.WorkspaceTypes.Any();

        if (!IsSeedingRequired)
        {
            await SeedWorkspaceTypesAsync(context);
            await SeedPhotosAsync(context);
            await SeedAmenitiesAsync(context);
            await SeedWorkspaceTypeAmenitiesAsync(context);
            await SeedWorkspacesAsync(context);
        }
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

    private static async Task SeedPhotosAsync(ApplicationDbContext context)
    {
        context.Photos.AddRange(
            new Photo
            {
                WorkspaceTypeId = 1,
                Title = "View 1",
                FilePath = "images/open-spaces/open-space1.jpg"
            },
            new Photo
            {
                WorkspaceTypeId = 1,
                Title = "View 2",
                FilePath = "images/open-spaces/open-space2.jpg"
            },
            new Photo
            {
                WorkspaceTypeId = 1,
                Title = "View 3",
                FilePath = "images/open-spaces/open-space3.jpg"
            },
            new Photo
            {
                WorkspaceTypeId = 2,
                Title = "View 1",
                FilePath = "images/private-rooms/private-room1.jpg"
            },
            new Photo
            {
                WorkspaceTypeId = 2,
                Title = "View 2",
                FilePath = "images/private-rooms/private-room2.jpg"
            },
            new Photo
            {
                WorkspaceTypeId = 2,
                Title = "View 3",
                FilePath = "images/private-rooms/private-room3.jpg"
            },
            new Photo
            {
                WorkspaceTypeId = 3,
                Title = "View 1",
                FilePath = "images/meeting-rooms/meeting-room1.jpg"
            },
            new Photo
            {
                WorkspaceTypeId = 3,
                Title = "View 2",
                FilePath = "images/meeting-rooms/meeting-room2.jpg"
            },
            new Photo
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
                Name = "Compact Desk",
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 11
            },
            new Workspace
            {
                Name = "Mid Desk",
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Cozy Desk",
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Vast Desk",
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 3
            },
            new Workspace
            {
                Name = "Elite Desk",
                WorkspaceTypeId = 1,
                Capacity = 1,
                Quantity = 2
            },
            new Workspace
            {
                Name = "Solo Private Room",
                WorkspaceTypeId = 2,
                Capacity = 1,
                Quantity = 8
            },
            new Workspace
            {
                Name = "Duo Private Room",
                WorkspaceTypeId = 2,
                Capacity = 2,
                Quantity = 5
            },
            new Workspace
            {
                Name = "Team Private Room",
                WorkspaceTypeId = 2,
                Capacity = 5,
                Quantity = 3
            },
            new Workspace
            {
                Name = "Collaboration Private Room",
                WorkspaceTypeId = 2,
                Capacity = 10,
                Quantity = 1
            },
            new Workspace
            {
                Name = "Conference Meeting Room",
                WorkspaceTypeId = 3,
                Capacity = 10,
                Quantity = 4
            },
            new Workspace
            {
                Name = "Big Conference Meeting Room",
                WorkspaceTypeId = 3,
                Capacity = 20,
                Quantity = 1
            }
        );
        
        await context.SaveChangesAsync();
    }
}