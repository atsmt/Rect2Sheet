FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 200.000000) * millimeter, vector(160.000000, 200.000000) * millimeter, vector(190.000000, 198.441000) * millimeter, vector(200.000000, 198.441000) * millimeter, vector(200.000000, 75.175700) * millimeter, vector(190.000000, 75.175700) * millimeter, vector(160.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(0.000000, 200.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(95.667738, 103.349441, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 2 from 0 (one_bend) ===
        // Flange 0->2: bend=70.06deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(200.000000, 136.808350, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 70.062018 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2
        var wallFace2 = qClosestTo(qCreatedBy(id + "flange0_2", EntityType.FACE), vector(201.705014, 136.808350, -4.700311) * millimeter);
        var faceN2 = evPlane(context, { "face" : wallFace2 }).normal;
        var skN2 = dot(faceN2, vector(-0.9400622805, 0.0, -0.3410027989)) >= 0 ? faceN2 : -faceN2;
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(217.0501, 60.0, -47.0031) * millimeter, skN2, vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 179.999989) * millimeter, vector(120.000000, 179.999989) * millimeter, vector(138.441000, -40.000004) * millimeter, vector(138.441000, -47.999973) * millimeter, vector(15.175700, -47.999973) * millimeter, vector(15.175700, -40.000004) * millimeter, vector(88.552794, -11.999969) * millimeter, vector(0.000000, -11.999969) * millimeter, vector(0.000000, 179.999989) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(217.050131, 136.808350, -47.003089) * millimeter),
            "booleanUnionScope" : wallFace2,
            "booleanOffset" : 0.0 * millimeter
        });
    });