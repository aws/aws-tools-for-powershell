/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Describes the specified images (AMIs, AKIs, and ARIs) available to you or all of the
    /// images available to you.
    /// 
    ///  
    /// <para>
    /// The images available to you include public images, private images that you own, and
    /// private images owned by other AWS accounts for which you have explicit launch permissions.
    /// </para><para>
    /// Recently deregistered images appear in the returned results for a short interval and
    /// then return empty results. After all instances that reference a deregistered AMI are
    /// terminated, specifying the ID of the image results in an error indicating that the
    /// AMI ID cannot be found.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2Image")]
    [OutputType("Amazon.EC2.Model.Image")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeImages API operation.", Operation = new[] {"DescribeImages"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeImagesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Image or Amazon.EC2.Model.DescribeImagesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.Image objects.",
        "The service call response (type Amazon.EC2.Model.DescribeImagesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ExecutableUser
        /// <summary>
        /// <para>
        /// <para>Scopes the images by users with explicit launch permissions. Specify an AWS account
        /// ID, <code>self</code> (the sender of the request), or <code>all</code> (public AMIs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutableBy","ExecutableUsers")]
        public System.String[] ExecutableUser { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><code>architecture</code> - The image architecture (<code>i386</code> | <code>x86_64</code>
        /// | <code>arm64</code>).</para></li><li><para><code>block-device-mapping.delete-on-termination</code> - A Boolean value that indicates
        /// whether the Amazon EBS volume is deleted on instance termination.</para></li><li><para><code>block-device-mapping.device-name</code> - The device name specified in the
        /// block device mapping (for example, <code>/dev/sdh</code> or <code>xvdh</code>).</para></li><li><para><code>block-device-mapping.snapshot-id</code> - The ID of the snapshot used for the
        /// EBS volume.</para></li><li><para><code>block-device-mapping.volume-size</code> - The volume size of the EBS volume,
        /// in GiB.</para></li><li><para><code>block-device-mapping.volume-type</code> - The volume type of the EBS volume
        /// (<code>gp2</code> | <code>io1</code> | <code>st1 </code>| <code>sc1</code> | <code>standard</code>).</para></li><li><para><code>block-device-mapping.encrypted</code> - A Boolean that indicates whether the
        /// EBS volume is encrypted.</para></li><li><para><code>description</code> - The description of the image (provided during image creation).</para></li><li><para><code>ena-support</code> - A Boolean that indicates whether enhanced networking with
        /// ENA is enabled.</para></li><li><para><code>hypervisor</code> - The hypervisor type (<code>ovm</code> | <code>xen</code>).</para></li><li><para><code>image-id</code> - The ID of the image.</para></li><li><para><code>image-type</code> - The image type (<code>machine</code> | <code>kernel</code>
        /// | <code>ramdisk</code>).</para></li><li><para><code>is-public</code> - A Boolean that indicates whether the image is public.</para></li><li><para><code>kernel-id</code> - The kernel ID.</para></li><li><para><code>manifest-location</code> - The location of the image manifest.</para></li><li><para><code>name</code> - The name of the AMI (provided during image creation).</para></li><li><para><code>owner-alias</code> - String value from an Amazon-maintained list (<code>amazon</code>
        /// | <code>aws-marketplace</code> | <code>microsoft</code>) of snapshot owners. Not to
        /// be confused with the user-configured AWS account alias, which is set from the IAM
        /// console.</para></li><li><para><code>owner-id</code> - The AWS account ID of the image owner.</para></li><li><para><code>platform</code> - The platform. To only list Windows-based AMIs, use <code>windows</code>.</para></li><li><para><code>product-code</code> - The product code.</para></li><li><para><code>product-code.type</code> - The type of the product code (<code>devpay</code>
        /// | <code>marketplace</code>).</para></li><li><para><code>ramdisk-id</code> - The RAM disk ID.</para></li><li><para><code>root-device-name</code> - The device name of the root device volume (for example,
        /// <code>/dev/sda1</code>).</para></li><li><para><code>root-device-type</code> - The type of the root device volume (<code>ebs</code>
        /// | <code>instance-store</code>).</para></li><li><para><code>state</code> - The state of the image (<code>available</code> | <code>pending</code>
        /// | <code>failed</code>).</para></li><li><para><code>state-reason-code</code> - The reason code for the state change.</para></li><li><para><code>state-reason-message</code> - The message for the state change.</para></li><li><para><code>sriov-net-support</code> - A value of <code>simple</code> indicates that enhanced
        /// networking with the Intel 82599 VF interface is enabled.</para></li><li><para><code>tag</code>:&lt;key&gt; - The key/value combination of a tag assigned to the
        /// resource. Use the tag key in the filter name and the tag value as the filter value.
        /// For example, to find all resources that have a tag with the key <code>Owner</code>
        /// and the value <code>TeamA</code>, specify <code>tag:Owner</code> for the filter name
        /// and <code>TeamA</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. Use this filter
        /// to find all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><code>virtualization-type</code> - The virtualization type (<code>paravirtual</code>
        /// | <code>hvm</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The image IDs.</para><para>Default: Describes all images available to you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ImageIds")]
        public System.String[] ImageId { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>Filters the images by the owner. Specify an AWS account ID, <code>self</code> (owner
        /// is the sender of the request), or an AWS owner alias (valid values are <code>amazon</code>
        /// | <code>aws-marketplace</code> | <code>microsoft</code>). Omitting this option returns
        /// all images for which you have launch permissions, regardless of ownership.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Owners")]
        public System.String[] Owner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Images'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeImagesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeImagesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Images";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImageId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImageId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImageId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeImagesResponse, GetEC2ImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImageId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ExecutableUser != null)
            {
                context.ExecutableUser = new List<System.String>(this.ExecutableUser);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.ImageId != null)
            {
                context.ImageId = new List<System.String>(this.ImageId);
            }
            if (this.Owner != null)
            {
                context.Owner = new List<System.String>(this.Owner);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeImagesRequest();
            
            if (cmdletContext.ExecutableUser != null)
            {
                request.ExecutableUsers = cmdletContext.ExecutableUser;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageIds = cmdletContext.ImageId;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owners = cmdletContext.Owner;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.EC2.Model.DescribeImagesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeImagesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeImages");
            try
            {
                #if DESKTOP
                return client.DescribeImages(request);
                #elif CORECLR
                return client.DescribeImagesAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> ExecutableUser { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public List<System.String> ImageId { get; set; }
            public List<System.String> Owner { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeImagesResponse, GetEC2ImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Images;
        }
        
    }
}
