/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Management.Automation;
using Amazon.PowerShell.Common;

using Amazon.Util;
using System.Collections.Generic;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Return values of available metadata categories for the current EC2 instance. For more information
    /// on EC2 instance metadata see http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-metadata.html.
    /// </summary>
    [Cmdlet("Get", "EC2InstanceMetadata", DefaultParameterSetName = ByCategoryParameterSet)]
    [OutputType("System.String")]
    [AWSCmdlet("Outputs the values corresponding to one or more EC2 instance metadata categories."
        + " The metadata can be addressed using one or more category enumeration values or by specifying one or more category paths."
        + " The list of known categories can also be enumerated to the pipeline."
        + " For metadata that yields a single value, a single string is output."
        + " For metadata that yields an array of string values, the array is enumerated to the pipeline.")
    ]
    public class GetEC2InstanceMetadataCmdlet : PSCmdlet
    {
        private const string ByCategoryParameterSet = "ByCategory";
        private const string ByPathParameterSet = "ByPath";
        private const string ListCategoriesParameterSet = "ListCategories";

        /// <summary>
        /// The currently known categories; some of these descend into further data 
        /// keys, others are 'convenience' categories that extract some relevant data 
        /// from data associated with another category (for example Region is a subfield
        /// in the data returned with the IdentityDocument category).
        /// </summary>
        public enum MetadataCategory
        {
            AmiId,
            LaunchIndex,
            ManifestPath,
            AncestorAmiId,
            BlockDeviceMapping,
            InstanceId,
            InstanceType,
            LocalHostname,
            LocalIpv4,
            KernelId,
            AvailabilityZone,
            ProductCode,
            PublicHostname,
            PublicIpv4,
            PublicKey,
            RamdiskId,
            Region,
            ReservationId,
            SecurityGroup,
            UserData,
            InstanceMonitoring,
            IdentityDocument,
            IdentitySignature,
            IdentityPkcs7
        }

        #region Parameter Category
        /// <summary>
        /// One or more categories of instance metadata to retrieve.
        /// </summary>
        [Parameter(ParameterSetName = ByCategoryParameterSet, Mandatory = true)]
        public MetadataCategory[] Category { get; set; }
        #endregion

        #region Parameter Path
        /// <summary>
        /// One or more instance metadata category paths to retrieve.
        /// </summary>
        [Parameter(ParameterSetName = ByPathParameterSet, Mandatory = true)]
        public string[] Path { get; set; }
        #endregion

        #region Parameter ListCategory
        /// <summary>
        /// Enumerates the categories that can be used with the -Category parameter to the pipeline.
        /// </summary>
        [Parameter(ParameterSetName = ListCategoriesParameterSet, Mandatory = true)]
        public SwitchParameter ListCategory { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (this.ParameterSetName.Equals(ByCategoryParameterSet, StringComparison.OrdinalIgnoreCase))
                MetadataFromCategory();
            else if (this.ParameterSetName.Equals(ByPathParameterSet, StringComparison.OrdinalIgnoreCase))
                MetadataFromPath();
            else
                EnumerateRecognizedCategories();
        }

        void MetadataFromCategory()
        {
            foreach (var c in Category)
            {
                try
                {
                    switch (c)
                    {
                        case MetadataCategory.AmiId:
                            WriteObject(EC2InstanceMetadata.AmiId);
                            break;
                        case MetadataCategory.AncestorAmiId:
                            WriteObject(EC2InstanceMetadata.AncestorAmiIds, true);
                            break;
                        case MetadataCategory.AvailabilityZone:
                            WriteObject(EC2InstanceMetadata.AvailabilityZone);
                            break;
                        case MetadataCategory.BlockDeviceMapping:
                            WriteObject(EC2InstanceMetadata.BlockDeviceMapping, true);
                            break;
                        case MetadataCategory.IdentityDocument:
                            WriteObject(EC2InstanceMetadata.IdentityDocument);
                            break;
                        case MetadataCategory.IdentityPkcs7:
                            WriteObject(EC2InstanceMetadata.IdentityPkcs7);
                            break;
                        case MetadataCategory.IdentitySignature:
                            WriteObject(EC2InstanceMetadata.IdentitySignature);
                            break;
                        case MetadataCategory.InstanceId:
                            WriteObject(EC2InstanceMetadata.InstanceId);
                            break;
                        case MetadataCategory.InstanceMonitoring:
                            WriteObject(EC2InstanceMetadata.InstanceMonitoring);
                            break;
                        case MetadataCategory.InstanceType:
                            WriteObject(EC2InstanceMetadata.InstanceType);
                            break;
                        case MetadataCategory.KernelId:
                            WriteObject(EC2InstanceMetadata.KernelId);
                            break;
                        case MetadataCategory.LaunchIndex:
                            WriteObject(EC2InstanceMetadata.AmiLaunchIndex);
                            break;
                        case MetadataCategory.LocalHostname:
                            WriteObject(EC2InstanceMetadata.LocalHostname);
                            break;
                        case MetadataCategory.LocalIpv4:
                            WriteObject(EC2InstanceMetadata.PrivateIpAddress);
                            break;
                        case MetadataCategory.ManifestPath:
                            WriteObject(EC2InstanceMetadata.AmiManifestPath);
                            break;
                        case MetadataCategory.ProductCode:
                            WriteObject(EC2InstanceMetadata.ProductCodes, true);
                            break;
                        case MetadataCategory.PublicHostname:
                            {
                                var interfaces = EC2InstanceMetadata.NetworkInterfaces;
                                var hostnames = new List<string>();
                                foreach (var i in interfaces)
                                {
                                    hostnames.Add(i.PublicHostname);
                                }

                                WriteObject(hostnames, true);
                            }
                            break;
                        case MetadataCategory.PublicIpv4:
                            {
                                var interfaces = EC2InstanceMetadata.NetworkInterfaces;
                                var addresses = new List<string>();
                                foreach (var i in interfaces)
                                {
                                    addresses.AddRange(i.PublicIPv4s);
                                }

                                WriteObject(addresses, true);
                            }
                            break;
                        case MetadataCategory.PublicKey:
                            WriteObject(EC2InstanceMetadata.PublicKey);
                            break;
                        case MetadataCategory.RamdiskId:
                            WriteObject(EC2InstanceMetadata.RamdiskId);
                            break;
                        case MetadataCategory.Region:
                            WriteObject(EC2InstanceMetadata.Region);
                            break;
                        case MetadataCategory.ReservationId:
                            WriteObject(EC2InstanceMetadata.ReservationId);
                            break;
                        case MetadataCategory.SecurityGroup:
                            WriteObject(EC2InstanceMetadata.SecurityGroups);
                            break;
                        case MetadataCategory.UserData:
                            WriteObject(EC2InstanceMetadata.UserData);
                            break;
                    }
                }
                catch (Exception e)
                {
                    var msg = string.Format("Failed to retrieve requested metadata. Error {0}.", e.Message);
                    WriteError(new ErrorRecord(e, msg, ErrorCategory.ReadError, c));
                }
            }
        }

        void MetadataFromPath()
        {
            foreach (var p in Path)
            {
                try
                {
                    var output = EC2InstanceMetadata.GetData(p);
                    WriteObject(output, true);
                }
                catch (Exception e)
                {
                    WriteError(new ErrorRecord(e, "PathNotFound", ErrorCategory.InvalidArgument, p));
                }
            }
        }

        void EnumerateRecognizedCategories()
        {
            WriteObject(Enum.GetNames(typeof(MetadataCategory)), true);
        }
    }
}
