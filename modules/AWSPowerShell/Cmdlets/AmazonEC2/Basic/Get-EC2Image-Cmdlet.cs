/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes one or more of the images (AMIs, AKIs, and ARIs) available to you. Images
    /// available to you include public images, private images that you own, and private images
    /// owned by other AWS accounts but for which you have explicit launch permissions.
    /// 
    ///  <note><para>
    /// Deregistered images are included in the returned results for an unspecified interval
    /// after deregistration.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2Image")]
    [OutputType("Amazon.EC2.Model.Image")]
    [AWSCmdlet("Invokes the DescribeImages operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeImages"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Image",
        "This cmdlet returns a collection of Image objects.",
        "The service call response (type Amazon.EC2.Model.DescribeImagesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ExecutableUser
        /// <summary>
        /// <para>
        /// <para>Scopes the images by users with explicit launch permissions. Specify an AWS account
        /// ID, <code>self</code> (the sender of the request), or <code>all</code> (public AMIs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("ExecutableBy","ExecutableUsers")]
        public System.String[] ExecutableUser { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>architecture</code> - The image architecture (<code>i386</code> | <code>x86_64</code>).</para></li><li><para><code>block-device-mapping.delete-on-termination</code> - A Boolean value that indicates
        /// whether the Amazon EBS volume is deleted on instance termination.</para></li><li><para><code>block-device-mapping.device-name</code> - The device name for the EBS volume
        /// (for example, <code>/dev/sdh</code>).</para></li><li><para><code>block-device-mapping.snapshot-id</code> - The ID of the snapshot used for the
        /// EBS volume.</para></li><li><para><code>block-device-mapping.volume-size</code> - The volume size of the EBS volume,
        /// in GiB.</para></li><li><para><code>block-device-mapping.volume-type</code> - The volume type of the EBS volume
        /// (<code>gp2</code> | <code>io1</code> | <code>st1 </code>| <code>sc1</code> | <code>standard</code>).</para></li><li><para><code>description</code> - The description of the image (provided during image creation).</para></li><li><para><code>hypervisor</code> - The hypervisor type (<code>ovm</code> | <code>xen</code>).</para></li><li><para><code>image-id</code> - The ID of the image.</para></li><li><para><code>image-type</code> - The image type (<code>machine</code> | <code>kernel</code>
        /// | <code>ramdisk</code>).</para></li><li><para><code>is-public</code> - A Boolean that indicates whether the image is public.</para></li><li><para><code>kernel-id</code> - The kernel ID.</para></li><li><para><code>manifest-location</code> - The location of the image manifest.</para></li><li><para><code>name</code> - The name of the AMI (provided during image creation).</para></li><li><para><code>owner-alias</code> - The AWS account alias (for example, <code>amazon</code>).</para></li><li><para><code>owner-id</code> - The AWS account ID of the image owner.</para></li><li><para><code>platform</code> - The platform. To only list Windows-based AMIs, use <code>windows</code>.</para></li><li><para><code>product-code</code> - The product code.</para></li><li><para><code>product-code.type</code> - The type of the product code (<code>devpay</code>
        /// | <code>marketplace</code>).</para></li><li><para><code>ramdisk-id</code> - The RAM disk ID.</para></li><li><para><code>root-device-name</code> - The name of the root device volume (for example,
        /// <code>/dev/sda1</code>).</para></li><li><para><code>root-device-type</code> - The type of the root device volume (<code>ebs</code>
        /// | <code>instance-store</code>).</para></li><li><para><code>state</code> - The state of the image (<code>available</code> | <code>pending</code>
        /// | <code>failed</code>).</para></li><li><para><code>state-reason-code</code> - The reason code for the state change.</para></li><li><para><code>state-reason-message</code> - The message for the state change.</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is
        /// independent of the tag-value filter. For example, if you use both the filter "tag-key=Purpose"
        /// and the filter "tag-value=X", you get any resources assigned both the tag key Purpose
        /// (regardless of what the tag's value is), and the tag value X (regardless of what the
        /// tag's key is). If you want to list only resources where Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i>
        /// filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>virtualization-type</code> - The virtualization type (<code>paravirtual</code>
        /// | <code>hvm</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>One or more image IDs.</para><para>Default: Describes all images available to you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ImageIds")]
        public System.String[] ImageId { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>Filters the images by the owner. Specify an AWS account ID, <code>amazon</code> (owner
        /// is Amazon), <code>aws-marketplace</code> (owner is AWS Marketplace), <code>self</code>
        /// (owner is the sender of the request). Omitting this option returns all images for
        /// which you have launch permissions, regardless of ownership.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Owners")]
        public System.String[] Owner { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ExecutableUser != null)
            {
                context.ExecutableUsers = new List<System.String>(this.ExecutableUser);
            }
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.ImageId != null)
            {
                context.ImageIds = new List<System.String>(this.ImageId);
            }
            if (this.Owner != null)
            {
                context.Owners = new List<System.String>(this.Owner);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeImagesRequest();
            
            if (cmdletContext.ExecutableUsers != null)
            {
                request.ExecutableUsers = cmdletContext.ExecutableUsers;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.ImageIds != null)
            {
                request.ImageIds = cmdletContext.ImageIds;
            }
            if (cmdletContext.Owners != null)
            {
                request.Owners = cmdletContext.Owners;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Images;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private static Amazon.EC2.Model.DescribeImagesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeImagesRequest request)
        {
            return client.DescribeImages(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> ExecutableUsers { get; set; }
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public List<System.String> ImageIds { get; set; }
            public List<System.String> Owners { get; set; }
        }
        
    }
}
