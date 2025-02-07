/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// private images owned by other Amazon Web Services accounts for which you have explicit
    /// launch permissions.
    /// </para><para>
    /// Recently deregistered images appear in the returned results for a short interval and
    /// then return empty results. After all instances that reference a deregistered AMI are
    /// terminated, specifying the ID of the image will eventually return an error indicating
    /// that the AMI ID cannot be found.
    /// </para><para>
    /// When Allowed AMIs is set to <c>enabled</c>, only allowed images are returned in the
    /// results, with the <c>imageAllowed</c> field set to <c>true</c> for each image. In
    /// <c>audit-mode</c>, the <c>imageAllowed</c> field is set to <c>true</c> for images
    /// that meet the account's Allowed AMIs criteria, and <c>false</c> for images that don't
    /// meet the criteria. For more information, see <a>EnableAllowedImagesSettings</a>.
    /// </para><important><para>
    /// We strongly recommend using only paginated requests. Unpaginated requests are susceptible
    /// to throttling and timeouts.
    /// </para></important><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2Image")]
    [OutputType("Amazon.EC2.Model.Image")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeImages API operation.", Operation = new[] {"DescribeImages"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeImagesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Image or Amazon.EC2.Model.DescribeImagesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.Image objects.",
        "The service call response (type Amazon.EC2.Model.DescribeImagesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExecutableUser
        /// <summary>
        /// <para>
        /// <para>Scopes the images by users with explicit launch permissions. Specify an Amazon Web
        /// Services account ID, <c>self</c> (the sender of the request), or <c>all</c> (public
        /// AMIs).</para><ul><li><para>If you specify an Amazon Web Services account ID that is not your own, only AMIs shared
        /// with that specific Amazon Web Services account ID are returned. However, AMIs that
        /// are shared with the account’s organization or organizational unit (OU) are not returned.</para></li><li><para>If you specify <c>self</c> or your own Amazon Web Services account ID, AMIs shared
        /// with your account are returned. In addition, AMIs that are shared with the organization
        /// or OU of which you are member are also returned. </para></li><li><para>If you specify <c>all</c>, all public AMIs are returned.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutableBy","ExecutableUsers")]
        public System.String[] ExecutableUser { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>architecture</c> - The image architecture (<c>i386</c> | <c>x86_64</c> | <c>arm64</c>
        /// | <c>x86_64_mac</c> | <c>arm64_mac</c>).</para></li><li><para><c>block-device-mapping.delete-on-termination</c> - A Boolean value that indicates
        /// whether the Amazon EBS volume is deleted on instance termination.</para></li><li><para><c>block-device-mapping.device-name</c> - The device name specified in the block
        /// device mapping (for example, <c>/dev/sdh</c> or <c>xvdh</c>).</para></li><li><para><c>block-device-mapping.snapshot-id</c> - The ID of the snapshot used for the Amazon
        /// EBS volume.</para></li><li><para><c>block-device-mapping.volume-size</c> - The volume size of the Amazon EBS volume,
        /// in GiB.</para></li><li><para><c>block-device-mapping.volume-type</c> - The volume type of the Amazon EBS volume
        /// (<c>io1</c> | <c>io2</c> | <c>gp2</c> | <c>gp3</c> | <c>sc1 </c>| <c>st1</c> | <c>standard</c>).</para></li><li><para><c>block-device-mapping.encrypted</c> - A Boolean that indicates whether the Amazon
        /// EBS volume is encrypted.</para></li><li><para><c>creation-date</c> - The time when the image was created, in the ISO 8601 format
        /// in the UTC time zone (YYYY-MM-DDThh:mm:ss.sssZ), for example, <c>2021-09-29T11:04:43.305Z</c>.
        /// You can use a wildcard (<c>*</c>), for example, <c>2021-09-29T*</c>, which matches
        /// an entire day.</para></li><li><para><c>description</c> - The description of the image (provided during image creation).</para></li><li><para><c>ena-support</c> - A Boolean that indicates whether enhanced networking with ENA
        /// is enabled.</para></li><li><para><c>hypervisor</c> - The hypervisor type (<c>ovm</c> | <c>xen</c>).</para></li><li><para><c>image-allowed</c> - A Boolean that indicates whether the image meets the criteria
        /// specified for Allowed AMIs.</para></li><li><para><c>image-id</c> - The ID of the image.</para></li><li><para><c>image-type</c> - The image type (<c>machine</c> | <c>kernel</c> | <c>ramdisk</c>).</para></li><li><para><c>is-public</c> - A Boolean that indicates whether the image is public.</para></li><li><para><c>kernel-id</c> - The kernel ID.</para></li><li><para><c>manifest-location</c> - The location of the image manifest.</para></li><li><para><c>name</c> - The name of the AMI (provided during image creation).</para></li><li><para><c>owner-alias</c> - The owner alias (<c>amazon</c> | <c>aws-backup-vault</c> | <c>aws-marketplace</c>).
        /// The valid aliases are defined in an Amazon-maintained list. This is not the Amazon
        /// Web Services account alias that can be set using the IAM console. We recommend that
        /// you use the <b>Owner</b> request parameter instead of this filter.</para></li><li><para><c>owner-id</c> - The Amazon Web Services account ID of the owner. We recommend that
        /// you use the <b>Owner</b> request parameter instead of this filter.</para></li><li><para><c>platform</c> - The platform. The only supported value is <c>windows</c>.</para></li><li><para><c>product-code</c> - The product code.</para></li><li><para><c>product-code.type</c> - The type of the product code (<c>marketplace</c>).</para></li><li><para><c>ramdisk-id</c> - The RAM disk ID.</para></li><li><para><c>root-device-name</c> - The device name of the root device volume (for example,
        /// <c>/dev/sda1</c>).</para></li><li><para><c>root-device-type</c> - The type of the root device volume (<c>ebs</c> | <c>instance-store</c>).</para></li><li><para><c>source-image-id</c> - The ID of the source AMI from which the AMI was created.</para></li><li><para><c>source-image-region</c> - The Region of the source AMI.</para></li><li><para><c>source-instance-id</c> - The ID of the instance that the AMI was created from
        /// if the AMI was created using CreateImage. This filter is applicable only if the AMI
        /// was created using <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateImage.html">CreateImage</a>.</para></li><li><para><c>state</c> - The state of the image (<c>available</c> | <c>pending</c> | <c>failed</c>).</para></li><li><para><c>state-reason-code</c> - The reason code for the state change.</para></li><li><para><c>state-reason-message</c> - The message for the state change.</para></li><li><para><c>sriov-net-support</c> - A value of <c>simple</c> indicates that enhanced networking
        /// with the Intel 82599 VF interface is enabled.</para></li><li><para><c>tag:&lt;key&gt;</c> - The key/value combination of a tag assigned to the resource.
        /// Use the tag key in the filter name and the tag value as the filter value. For example,
        /// to find all resources that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>,
        /// specify <c>tag:Owner</c> for the filter name and <c>TeamA</c> for the filter value.</para></li><li><para><c>tag-key</c> - The key of a tag assigned to the resource. Use this filter to find
        /// all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><c>virtualization-type</c> - The virtualization type (<c>paravirtual</c> | <c>hvm</c>).</para></li></ul>
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
        
        #region Parameter IncludeDeprecated
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include deprecated AMIs.</para><para>Default: No deprecated AMIs are included in the response.</para><note><para>If you are the AMI owner, all deprecated AMIs appear in the response regardless of
        /// what you specify for this parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeDeprecated { get; set; }
        #endregion
        
        #region Parameter IncludeDisabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include disabled AMIs.</para><para>Default: No disabled AMIs are included in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeDisabled { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>Scopes the results to images with the specified owners. You can specify a combination
        /// of Amazon Web Services account IDs, <c>self</c>, <c>amazon</c>, <c>aws-backup-vault</c>,
        /// and <c>aws-marketplace</c>. If you omit this parameter, the results include all images
        /// for which you have launch permissions, regardless of ownership.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Owners")]
        public System.String[] Owner { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Query-Requests.html#api-pagination">Pagination</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned from a previous paginated request. Pagination continues from the
        /// end of the items returned by the previous request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeImagesResponse, GetEC2ImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.IncludeDeprecated = this.IncludeDeprecated;
            context.IncludeDisabled = this.IncludeDisabled;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
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
            if (cmdletContext.IncludeDeprecated != null)
            {
                request.IncludeDeprecated = cmdletContext.IncludeDeprecated.Value;
            }
            if (cmdletContext.IncludeDisabled != null)
            {
                request.IncludeDisabled = cmdletContext.IncludeDisabled.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owners = cmdletContext.Owner;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
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
            public System.Boolean? IncludeDeprecated { get; set; }
            public System.Boolean? IncludeDisabled { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Owner { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeImagesResponse, GetEC2ImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Images;
        }
        
    }
}
