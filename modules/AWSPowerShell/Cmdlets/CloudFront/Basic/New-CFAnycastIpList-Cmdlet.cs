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
using System.Threading;
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Creates an Anycast static IP list.
    /// </summary>
    [Cmdlet("New", "CFAnycastIpList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.AnycastIpList")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateAnycastIpList API operation.", Operation = new[] {"CreateAnycastIpList"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateAnycastIpListResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.AnycastIpList or Amazon.CloudFront.Model.CreateAnycastIpListResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.AnycastIpList object.",
        "The service call response (type Amazon.CloudFront.Model.CreateAnycastIpListResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCFAnycastIpListCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type for the Anycast static IP list. You can specify one of the following
        /// options:</para><ul><li><para><c>ipv4</c> only</para></li><li><para><c>ipv6</c> only </para></li><li><para><c>dualstack</c> - Allocate a list of both IPv4 and IPv6 addresses</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFront.IpAddressType")]
        public Amazon.CloudFront.IpAddressType IpAddressType { get; set; }
        #endregion
        
        #region Parameter IpamCidrConfig
        /// <summary>
        /// <para>
        /// <para> A list of IPAM CIDR configurations that specify the IP address ranges and IPAM pool
        /// settings for creating the Anycast static IP list. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IpamCidrConfigs")]
        public Amazon.CloudFront.Model.IpamCidrConfig[] IpamCidrConfig { get; set; }
        #endregion
        
        #region Parameter IpCount
        /// <summary>
        /// <para>
        /// <para>The number of static IP addresses that are allocated to the Anycast static IP list.
        /// Valid values: 21 or 3.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? IpCount { get; set; }
        #endregion
        
        #region Parameter Tags_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains <c>Tag</c> elements.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags_Items")]
        public Amazon.CloudFront.Model.Tag[] Tags_Item { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the Anycast static IP list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnycastIpList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateAnycastIpListResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateAnycastIpListResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnycastIpList";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFAnycastIpList (CreateAnycastIpList)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateAnycastIpListResponse, NewCFAnycastIpListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IpAddressType = this.IpAddressType;
            if (this.IpamCidrConfig != null)
            {
                context.IpamCidrConfig = new List<Amazon.CloudFront.Model.IpamCidrConfig>(this.IpamCidrConfig);
            }
            context.IpCount = this.IpCount;
            #if MODULAR
            if (this.IpCount == null && ParameterWasBound(nameof(this.IpCount)))
            {
                WriteWarning("You are passing $null as a value for parameter IpCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tags_Item != null)
            {
                context.Tags_Item = new List<Amazon.CloudFront.Model.Tag>(this.Tags_Item);
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
            var request = new Amazon.CloudFront.Model.CreateAnycastIpListRequest();
            
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.IpamCidrConfig != null)
            {
                request.IpamCidrConfigs = cmdletContext.IpamCidrConfig;
            }
            if (cmdletContext.IpCount != null)
            {
                request.IpCount = cmdletContext.IpCount.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Tags
            var requestTagsIsNull = true;
            request.Tags = new Amazon.CloudFront.Model.Tags();
            List<Amazon.CloudFront.Model.Tag> requestTags_tags_Item = null;
            if (cmdletContext.Tags_Item != null)
            {
                requestTags_tags_Item = cmdletContext.Tags_Item;
            }
            if (requestTags_tags_Item != null)
            {
                request.Tags.Items = requestTags_tags_Item;
                requestTagsIsNull = false;
            }
             // determine if request.Tags should be set to null
            if (requestTagsIsNull)
            {
                request.Tags = null;
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
        
        private Amazon.CloudFront.Model.CreateAnycastIpListResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateAnycastIpListRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateAnycastIpList");
            try
            {
                return client.CreateAnycastIpListAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CloudFront.IpAddressType IpAddressType { get; set; }
            public List<Amazon.CloudFront.Model.IpamCidrConfig> IpamCidrConfig { get; set; }
            public System.Int32? IpCount { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.CloudFront.Model.Tag> Tags_Item { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateAnycastIpListResponse, NewCFAnycastIpListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnycastIpList;
        }
        
    }
}
