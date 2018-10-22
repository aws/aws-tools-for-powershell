﻿/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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

using System.IO;
using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    internal static class AmazonEC2Helper
    {
        /// <summary>
        /// Converts a list of string instance ids, RunningInstance objects or Reservation objects 
        /// to a collection of string instance ids
        /// </summary>
        /// <param name="instances"></param>
        /// <returns></returns>
        public static List<string> InstanceParamToIDs(params object[] instances)
        {
            var ids = new List<string>();
            if (instances != null)
            {
                foreach (object o in instances)
                {
                    string instanceId = string.Empty;
                    var reservation = o as Reservation;
                    if (reservation != null)
                    {
                        ids.AddRange(reservation.Instances.Select(ri => ri.InstanceId));
                        continue;
                    }

                    var runningInstance = o as Instance;
                    if (runningInstance != null)
                    {
                        ids.Add(runningInstance.InstanceId);
                        continue;
                    }

                    // PSObject type can be obtained if the user does this:
                    //    PS C:\> $instanceid = Get-EC2InstanceMetadata -Category InstanceId
                    //    (or $instanceid = Invoke-RestMethod 'http://169.254.169.254/latest/meta-data/instance-id')
                    //    PS C:\> Get-EC2Instance -InstanceId $instanceid
                    // $instanceid appears as a string when inspected, but the 'as string' cast
                    // fails. If they quote surround $instanceid though, the 'as string' 
                    // cast succeeds (as you'd hope). Calling ToString on the PSObject
                    // gets us what we need.
                    var psobject = o as System.Management.Automation.PSObject;
                    if (psobject != null)
                    {
                        ids.Add(psobject.ToString());
                        continue;
                    }

                    var id = o as string;
                    if (id != null)
                    {
                        ids.Add(id);
                    }
                }
            }
            return ids;
        }

        public static string LoadUserData(string userData, string userDataFile, bool encodeData)
        {
            if (userData == null && userDataFile == null)
                return null;

            string loadedData;
            if (!string.IsNullOrEmpty(userDataFile))
            {
                // coreclr StreamReader does not have ctor that takes filename
                using (var stream = File.OpenRead(userDataFile))
                using (var reader = new StreamReader(stream))
                {
                    loadedData = reader.ReadToEnd();
                }
            }
            else
                loadedData = userData;

            return encodeData
                ? Convert.ToBase64String(Encoding.UTF8.GetBytes(loadedData))
                : loadedData;
        }

        /// <summary>
        /// Constructs a RequestLaunchTemplateData suitable for use in New-EC2LaunchTemplate[Version],
        /// from a response shape output by Get-EC2LaunchTemplateData. This enables pipelining of the
        /// form Get-EC2LaunchTemplateData | New-EC2LaunchTemplateData[Version].This works around
        /// the lack of copy constructors in the sdk.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static RequestLaunchTemplateData FromResponseTemplateData(ResponseLaunchTemplateData input)
        {
            if (input == null)
                return null;

            var output = new RequestLaunchTemplateData
            {
                KernelId = input.KernelId,
                EbsOptimized = input.EbsOptimized,
                ImageId = input.ImageId,
                InstanceType = input.InstanceType,
                KeyName = input.KeyName,
                RamDiskId = input.RamDiskId,
                DisableApiTermination = input.DisableApiTermination,
                InstanceInitiatedShutdownBehavior = input.InstanceInitiatedShutdownBehavior,
                UserData = input.UserData
            };

            if (input.SecurityGroupIds != null && input.SecurityGroupIds.Count > 0)
            {
                output.SecurityGroupIds = new List<string>(input.SecurityGroupIds);    
            }

            if (input.SecurityGroups != null && input.SecurityGroups.Count > 0)
            {
                output.SecurityGroups = new List<string>(input.SecurityGroups);
            }

            if (input.IamInstanceProfile != null)
            {
                output.IamInstanceProfile = new LaunchTemplateIamInstanceProfileSpecificationRequest
                {
                    Name = input.IamInstanceProfile.Name,
                    Arn = input.IamInstanceProfile.Arn
                };
            }

            if (input.BlockDeviceMappings != null && input.BlockDeviceMappings.Count > 0)
            {
                output.BlockDeviceMappings = new List<LaunchTemplateBlockDeviceMappingRequest>();
                foreach (var bdm in input.BlockDeviceMappings)
                {
                    output.BlockDeviceMappings.Add(new LaunchTemplateBlockDeviceMappingRequest
                    {
                        DeviceName = bdm.DeviceName,
                        NoDevice = bdm.NoDevice,
                        VirtualName = bdm.VirtualName,
                        Ebs = new LaunchTemplateEbsBlockDeviceRequest
                        {
                            DeleteOnTermination = bdm.Ebs.DeleteOnTermination,
                            Encrypted = bdm.Ebs.Encrypted,
                            Iops = bdm.Ebs.Iops,
                            KmsKeyId = bdm.Ebs.KmsKeyId,
                            SnapshotId = bdm.Ebs.SnapshotId,
                            VolumeSize = bdm.Ebs.VolumeSize,
                            VolumeType = bdm.Ebs.VolumeType
                        }
                    });                    
                }                
            }

            if (input.NetworkInterfaces != null && input.NetworkInterfaces.Count > 0)
            {
                output.NetworkInterfaces = new List<LaunchTemplateInstanceNetworkInterfaceSpecificationRequest>();
                foreach (var ni in input.NetworkInterfaces)
                {
                    var nispec = new LaunchTemplateInstanceNetworkInterfaceSpecificationRequest
                    {
                        DeleteOnTermination = ni.DeleteOnTermination,
                        AssociatePublicIpAddress = ni.AssociatePublicIpAddress,
                        Description = ni.Description,
                        DeviceIndex = ni.DeviceIndex,
                        Ipv6AddressCount = ni.Ipv6AddressCount,
                        NetworkInterfaceId = ni.NetworkInterfaceId,
                        PrivateIpAddress = ni.PrivateIpAddress,
                        SecondaryPrivateIpAddressCount = ni.SecondaryPrivateIpAddressCount,
                        SubnetId = ni.SubnetId
                    };

                    if (ni.Groups != null && ni.Groups.Count > 0)
                    {
                        nispec.Groups = new List<string>(ni.Groups);    
                    }

                    if (ni.Ipv6AddressCount > 0)
                    {
                        nispec.Ipv6Addresses = new List<InstanceIpv6AddressRequest>();
                        foreach (var ip6 in ni.Ipv6Addresses)
                        {
                            nispec.Ipv6Addresses.Add(new InstanceIpv6AddressRequest
                            {
                                Ipv6Address = ip6.Ipv6Address
                            });
                        }
                    }

                    if (ni.PrivateIpAddresses != null && ni.PrivateIpAddresses.Count > 0)
                    {
                        nispec.PrivateIpAddresses = new List<PrivateIpAddressSpecification>();
                        foreach (var pip in ni.PrivateIpAddresses)
                        {
                            nispec.PrivateIpAddresses.Add(new PrivateIpAddressSpecification
                            {
                                PrivateIpAddress = pip.PrivateIpAddress,
                                Primary = pip.Primary
                            });
                        }
                    }

                    output.NetworkInterfaces.Add(nispec);
                }
            }

            if (input.Monitoring != null)
            {
                output.Monitoring = new LaunchTemplatesMonitoringRequest
                {
                    Enabled = input.Monitoring.Enabled
                };
            }

            if (input.Placement != null)
            {
                output.Placement = new LaunchTemplatePlacementRequest
                {
                    Affinity = input.Placement.Affinity,
                    AvailabilityZone = input.Placement.AvailabilityZone,
                    GroupName = input.Placement.GroupName,
                    HostId = input.Placement.HostId,
                    SpreadDomain = input.Placement.SpreadDomain,
                    Tenancy = input.Placement.Tenancy
                };
            }

            if (input.TagSpecifications != null && input.TagSpecifications.Count > 0)
            {
                output.TagSpecifications = new List<LaunchTemplateTagSpecificationRequest>();
                foreach (var ts in input.TagSpecifications)
                {
                    var tagspec = new LaunchTemplateTagSpecificationRequest
                    {
                        ResourceType = ts.ResourceType,
                        Tags = new List<Tag>()
                    };
                    foreach (var t in ts.Tags)
                    {
                        tagspec.Tags.Add(new Tag
                        {
                            Key = t.Key,
                            Value = t.Value
                        });
                    }
                    output.TagSpecifications.Add(tagspec);
                }
            }

            if (input.ElasticGpuSpecifications != null && input.ElasticGpuSpecifications.Count > 0)
            {
                output.ElasticGpuSpecifications = new List<ElasticGpuSpecification>();
                foreach (var egpu in input.ElasticGpuSpecifications)
                {
                    output.ElasticGpuSpecifications.Add(new ElasticGpuSpecification
                    {
                        Type = egpu.Type
                    });
                }
            }

            if (input.InstanceMarketOptions != null)
            {
                output.InstanceMarketOptions = new LaunchTemplateInstanceMarketOptionsRequest
                {
                    MarketType = input.InstanceMarketOptions.MarketType,
                    SpotOptions = new LaunchTemplateSpotMarketOptionsRequest
                    {
                        BlockDurationMinutes = input.InstanceMarketOptions.SpotOptions.BlockDurationMinutes,
                        InstanceInterruptionBehavior =
                            input.InstanceMarketOptions.SpotOptions.InstanceInterruptionBehavior,
                        MaxPrice = input.InstanceMarketOptions.SpotOptions.MaxPrice,
                        SpotInstanceType = input.InstanceMarketOptions.SpotOptions.SpotInstanceType,
                        ValidUntilUtc = input.InstanceMarketOptions.SpotOptions.ValidUntil
                    }
                };
            }

            if (input.CreditSpecification != null)
            {
                output.CreditSpecification = new CreditSpecificationRequest
                {
                    CpuCredits = input.CreditSpecification.CpuCredits
                };
            }

            return output;
        }
    }
}
