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
    /// Create an Amazon CloudFront VPC origin.
    /// </summary>
    [Cmdlet("New", "CFVpcOrigin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateVpcOriginResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateVpcOrigin API operation.", Operation = new[] {"CreateVpcOrigin"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateVpcOriginResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateVpcOriginResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateVpcOriginResponse object containing multiple properties."
    )]
    public partial class NewCFVpcOriginCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter VpcOriginEndpointConfig_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the CloudFront VPC origin endpoint configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String VpcOriginEndpointConfig_Arn { get; set; }
        #endregion
        
        #region Parameter VpcOriginEndpointConfig_HTTPPort
        /// <summary>
        /// <para>
        /// <para>The HTTP port for the CloudFront VPC origin endpoint configuration. The default value
        /// is <c>80</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? VpcOriginEndpointConfig_HTTPPort { get; set; }
        #endregion
        
        #region Parameter VpcOriginEndpointConfig_HTTPSPort
        /// <summary>
        /// <para>
        /// <para>The HTTPS port of the CloudFront VPC origin endpoint configuration. The default value
        /// is <c>443</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? VpcOriginEndpointConfig_HTTPSPort { get; set; }
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
        
        #region Parameter OriginSslProtocols_Item
        /// <summary>
        /// <para>
        /// <para>A list that contains allowed SSL/TLS protocols for this distribution.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOriginEndpointConfig_OriginSslProtocols_Items")]
        public System.String[] OriginSslProtocols_Item { get; set; }
        #endregion
        
        #region Parameter VpcOriginEndpointConfig_Name
        /// <summary>
        /// <para>
        /// <para>The name of the CloudFront VPC origin endpoint configuration.</para>
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
        public System.String VpcOriginEndpointConfig_Name { get; set; }
        #endregion
        
        #region Parameter VpcOriginEndpointConfig_OriginProtocolPolicy
        /// <summary>
        /// <para>
        /// <para>The origin protocol policy for the CloudFront VPC origin endpoint configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudFront.OriginProtocolPolicy")]
        public Amazon.CloudFront.OriginProtocolPolicy VpcOriginEndpointConfig_OriginProtocolPolicy { get; set; }
        #endregion
        
        #region Parameter OriginSslProtocols_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of SSL/TLS protocols that you want to allow CloudFront to use when establishing
        /// an HTTPS connection with this origin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOriginEndpointConfig_OriginSslProtocols_Quantity")]
        public System.Int32? OriginSslProtocols_Quantity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateVpcOriginResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateVpcOriginResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcOriginEndpointConfig_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFVpcOrigin (CreateVpcOrigin)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateVpcOriginResponse, NewCFVpcOriginCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Tags_Item != null)
            {
                context.Tags_Item = new List<Amazon.CloudFront.Model.Tag>(this.Tags_Item);
            }
            context.VpcOriginEndpointConfig_Arn = this.VpcOriginEndpointConfig_Arn;
            #if MODULAR
            if (this.VpcOriginEndpointConfig_Arn == null && ParameterWasBound(nameof(this.VpcOriginEndpointConfig_Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcOriginEndpointConfig_Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcOriginEndpointConfig_HTTPPort = this.VpcOriginEndpointConfig_HTTPPort;
            #if MODULAR
            if (this.VpcOriginEndpointConfig_HTTPPort == null && ParameterWasBound(nameof(this.VpcOriginEndpointConfig_HTTPPort)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcOriginEndpointConfig_HTTPPort which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcOriginEndpointConfig_HTTPSPort = this.VpcOriginEndpointConfig_HTTPSPort;
            #if MODULAR
            if (this.VpcOriginEndpointConfig_HTTPSPort == null && ParameterWasBound(nameof(this.VpcOriginEndpointConfig_HTTPSPort)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcOriginEndpointConfig_HTTPSPort which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcOriginEndpointConfig_Name = this.VpcOriginEndpointConfig_Name;
            #if MODULAR
            if (this.VpcOriginEndpointConfig_Name == null && ParameterWasBound(nameof(this.VpcOriginEndpointConfig_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcOriginEndpointConfig_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcOriginEndpointConfig_OriginProtocolPolicy = this.VpcOriginEndpointConfig_OriginProtocolPolicy;
            #if MODULAR
            if (this.VpcOriginEndpointConfig_OriginProtocolPolicy == null && ParameterWasBound(nameof(this.VpcOriginEndpointConfig_OriginProtocolPolicy)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcOriginEndpointConfig_OriginProtocolPolicy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OriginSslProtocols_Item != null)
            {
                context.OriginSslProtocols_Item = new List<System.String>(this.OriginSslProtocols_Item);
            }
            context.OriginSslProtocols_Quantity = this.OriginSslProtocols_Quantity;
            
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
            var request = new Amazon.CloudFront.Model.CreateVpcOriginRequest();
            
            
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
            
             // populate VpcOriginEndpointConfig
            var requestVpcOriginEndpointConfigIsNull = true;
            request.VpcOriginEndpointConfig = new Amazon.CloudFront.Model.VpcOriginEndpointConfig();
            System.String requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_Arn = null;
            if (cmdletContext.VpcOriginEndpointConfig_Arn != null)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_Arn = cmdletContext.VpcOriginEndpointConfig_Arn;
            }
            if (requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_Arn != null)
            {
                request.VpcOriginEndpointConfig.Arn = requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_Arn;
                requestVpcOriginEndpointConfigIsNull = false;
            }
            System.Int32? requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_HTTPPort = null;
            if (cmdletContext.VpcOriginEndpointConfig_HTTPPort != null)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_HTTPPort = cmdletContext.VpcOriginEndpointConfig_HTTPPort.Value;
            }
            if (requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_HTTPPort != null)
            {
                request.VpcOriginEndpointConfig.HTTPPort = requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_HTTPPort.Value;
                requestVpcOriginEndpointConfigIsNull = false;
            }
            System.Int32? requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_HTTPSPort = null;
            if (cmdletContext.VpcOriginEndpointConfig_HTTPSPort != null)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_HTTPSPort = cmdletContext.VpcOriginEndpointConfig_HTTPSPort.Value;
            }
            if (requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_HTTPSPort != null)
            {
                request.VpcOriginEndpointConfig.HTTPSPort = requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_HTTPSPort.Value;
                requestVpcOriginEndpointConfigIsNull = false;
            }
            System.String requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_Name = null;
            if (cmdletContext.VpcOriginEndpointConfig_Name != null)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_Name = cmdletContext.VpcOriginEndpointConfig_Name;
            }
            if (requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_Name != null)
            {
                request.VpcOriginEndpointConfig.Name = requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_Name;
                requestVpcOriginEndpointConfigIsNull = false;
            }
            Amazon.CloudFront.OriginProtocolPolicy requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginProtocolPolicy = null;
            if (cmdletContext.VpcOriginEndpointConfig_OriginProtocolPolicy != null)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginProtocolPolicy = cmdletContext.VpcOriginEndpointConfig_OriginProtocolPolicy;
            }
            if (requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginProtocolPolicy != null)
            {
                request.VpcOriginEndpointConfig.OriginProtocolPolicy = requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginProtocolPolicy;
                requestVpcOriginEndpointConfigIsNull = false;
            }
            Amazon.CloudFront.Model.OriginSslProtocols requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols = null;
            
             // populate OriginSslProtocols
            var requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocolsIsNull = true;
            requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols = new Amazon.CloudFront.Model.OriginSslProtocols();
            List<System.String> requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols_originSslProtocols_Item = null;
            if (cmdletContext.OriginSslProtocols_Item != null)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols_originSslProtocols_Item = cmdletContext.OriginSslProtocols_Item;
            }
            if (requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols_originSslProtocols_Item != null)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols.Items = requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols_originSslProtocols_Item;
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocolsIsNull = false;
            }
            System.Int32? requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols_originSslProtocols_Quantity = null;
            if (cmdletContext.OriginSslProtocols_Quantity != null)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols_originSslProtocols_Quantity = cmdletContext.OriginSslProtocols_Quantity.Value;
            }
            if (requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols_originSslProtocols_Quantity != null)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols.Quantity = requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols_originSslProtocols_Quantity.Value;
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocolsIsNull = false;
            }
             // determine if requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols should be set to null
            if (requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocolsIsNull)
            {
                requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols = null;
            }
            if (requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols != null)
            {
                request.VpcOriginEndpointConfig.OriginSslProtocols = requestVpcOriginEndpointConfig_vpcOriginEndpointConfig_OriginSslProtocols;
                requestVpcOriginEndpointConfigIsNull = false;
            }
             // determine if request.VpcOriginEndpointConfig should be set to null
            if (requestVpcOriginEndpointConfigIsNull)
            {
                request.VpcOriginEndpointConfig = null;
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
        
        private Amazon.CloudFront.Model.CreateVpcOriginResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateVpcOriginRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateVpcOrigin");
            try
            {
                return client.CreateVpcOriginAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CloudFront.Model.Tag> Tags_Item { get; set; }
            public System.String VpcOriginEndpointConfig_Arn { get; set; }
            public System.Int32? VpcOriginEndpointConfig_HTTPPort { get; set; }
            public System.Int32? VpcOriginEndpointConfig_HTTPSPort { get; set; }
            public System.String VpcOriginEndpointConfig_Name { get; set; }
            public Amazon.CloudFront.OriginProtocolPolicy VpcOriginEndpointConfig_OriginProtocolPolicy { get; set; }
            public List<System.String> OriginSslProtocols_Item { get; set; }
            public System.Int32? OriginSslProtocols_Quantity { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateVpcOriginResponse, NewCFVpcOriginCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
