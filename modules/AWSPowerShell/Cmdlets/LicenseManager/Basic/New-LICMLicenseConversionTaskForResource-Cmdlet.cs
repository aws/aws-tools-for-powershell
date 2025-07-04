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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Creates a new license conversion task.
    /// </summary>
    [Cmdlet("New", "LICMLicenseConversionTaskForResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS License Manager CreateLicenseConversionTaskForResource API operation.", Operation = new[] {"CreateLicenseConversionTaskForResource"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceResponse))]
    [AWSCmdletOutput("System.String or Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLICMLicenseConversionTaskForResourceCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DestinationLicenseContext_ProductCode
        /// <summary>
        /// <para>
        /// <para>Product codes referred to in the license conversion process.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationLicenseContext_ProductCodes")]
        public Amazon.LicenseManager.Model.ProductCodeListItem[] DestinationLicenseContext_ProductCode { get; set; }
        #endregion
        
        #region Parameter SourceLicenseContext_ProductCode
        /// <summary>
        /// <para>
        /// <para>Product codes referred to in the license conversion process.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceLicenseContext_ProductCodes")]
        public Amazon.LicenseManager.Model.ProductCodeListItem[] SourceLicenseContext_ProductCode { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the resource you are converting the license type for.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter DestinationLicenseContext_UsageOperation
        /// <summary>
        /// <para>
        /// <para>The Usage operation value that corresponds to the license type you are converting
        /// your resource from. For more information about which platforms correspond to which
        /// usage operation values see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/billing-info-fields.html#billing-info">Sample
        /// data: usage operation by platform </a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationLicenseContext_UsageOperation { get; set; }
        #endregion
        
        #region Parameter SourceLicenseContext_UsageOperation
        /// <summary>
        /// <para>
        /// <para>The Usage operation value that corresponds to the license type you are converting
        /// your resource from. For more information about which platforms correspond to which
        /// usage operation values see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/billing-info-fields.html#billing-info">Sample
        /// data: usage operation by platform </a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceLicenseContext_UsageOperation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LicenseConversionTaskId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LicenseConversionTaskId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LICMLicenseConversionTaskForResource (CreateLicenseConversionTaskForResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceResponse, NewLICMLicenseConversionTaskForResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DestinationLicenseContext_ProductCode != null)
            {
                context.DestinationLicenseContext_ProductCode = new List<Amazon.LicenseManager.Model.ProductCodeListItem>(this.DestinationLicenseContext_ProductCode);
            }
            context.DestinationLicenseContext_UsageOperation = this.DestinationLicenseContext_UsageOperation;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SourceLicenseContext_ProductCode != null)
            {
                context.SourceLicenseContext_ProductCode = new List<Amazon.LicenseManager.Model.ProductCodeListItem>(this.SourceLicenseContext_ProductCode);
            }
            context.SourceLicenseContext_UsageOperation = this.SourceLicenseContext_UsageOperation;
            
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
            var request = new Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceRequest();
            
            
             // populate DestinationLicenseContext
            var requestDestinationLicenseContextIsNull = true;
            request.DestinationLicenseContext = new Amazon.LicenseManager.Model.LicenseConversionContext();
            List<Amazon.LicenseManager.Model.ProductCodeListItem> requestDestinationLicenseContext_destinationLicenseContext_ProductCode = null;
            if (cmdletContext.DestinationLicenseContext_ProductCode != null)
            {
                requestDestinationLicenseContext_destinationLicenseContext_ProductCode = cmdletContext.DestinationLicenseContext_ProductCode;
            }
            if (requestDestinationLicenseContext_destinationLicenseContext_ProductCode != null)
            {
                request.DestinationLicenseContext.ProductCodes = requestDestinationLicenseContext_destinationLicenseContext_ProductCode;
                requestDestinationLicenseContextIsNull = false;
            }
            System.String requestDestinationLicenseContext_destinationLicenseContext_UsageOperation = null;
            if (cmdletContext.DestinationLicenseContext_UsageOperation != null)
            {
                requestDestinationLicenseContext_destinationLicenseContext_UsageOperation = cmdletContext.DestinationLicenseContext_UsageOperation;
            }
            if (requestDestinationLicenseContext_destinationLicenseContext_UsageOperation != null)
            {
                request.DestinationLicenseContext.UsageOperation = requestDestinationLicenseContext_destinationLicenseContext_UsageOperation;
                requestDestinationLicenseContextIsNull = false;
            }
             // determine if request.DestinationLicenseContext should be set to null
            if (requestDestinationLicenseContextIsNull)
            {
                request.DestinationLicenseContext = null;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            
             // populate SourceLicenseContext
            var requestSourceLicenseContextIsNull = true;
            request.SourceLicenseContext = new Amazon.LicenseManager.Model.LicenseConversionContext();
            List<Amazon.LicenseManager.Model.ProductCodeListItem> requestSourceLicenseContext_sourceLicenseContext_ProductCode = null;
            if (cmdletContext.SourceLicenseContext_ProductCode != null)
            {
                requestSourceLicenseContext_sourceLicenseContext_ProductCode = cmdletContext.SourceLicenseContext_ProductCode;
            }
            if (requestSourceLicenseContext_sourceLicenseContext_ProductCode != null)
            {
                request.SourceLicenseContext.ProductCodes = requestSourceLicenseContext_sourceLicenseContext_ProductCode;
                requestSourceLicenseContextIsNull = false;
            }
            System.String requestSourceLicenseContext_sourceLicenseContext_UsageOperation = null;
            if (cmdletContext.SourceLicenseContext_UsageOperation != null)
            {
                requestSourceLicenseContext_sourceLicenseContext_UsageOperation = cmdletContext.SourceLicenseContext_UsageOperation;
            }
            if (requestSourceLicenseContext_sourceLicenseContext_UsageOperation != null)
            {
                request.SourceLicenseContext.UsageOperation = requestSourceLicenseContext_sourceLicenseContext_UsageOperation;
                requestSourceLicenseContextIsNull = false;
            }
             // determine if request.SourceLicenseContext should be set to null
            if (requestSourceLicenseContextIsNull)
            {
                request.SourceLicenseContext = null;
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
        
        private Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CreateLicenseConversionTaskForResource");
            try
            {
                return client.CreateLicenseConversionTaskForResourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.LicenseManager.Model.ProductCodeListItem> DestinationLicenseContext_ProductCode { get; set; }
            public System.String DestinationLicenseContext_UsageOperation { get; set; }
            public System.String ResourceArn { get; set; }
            public List<Amazon.LicenseManager.Model.ProductCodeListItem> SourceLicenseContext_ProductCode { get; set; }
            public System.String SourceLicenseContext_UsageOperation { get; set; }
            public System.Func<Amazon.LicenseManager.Model.CreateLicenseConversionTaskForResourceResponse, NewLICMLicenseConversionTaskForResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LicenseConversionTaskId;
        }
        
    }
}
