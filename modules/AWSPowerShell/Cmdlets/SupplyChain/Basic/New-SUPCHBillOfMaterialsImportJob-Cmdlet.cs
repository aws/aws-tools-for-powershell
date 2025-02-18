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
using Amazon.SupplyChain;
using Amazon.SupplyChain.Model;

namespace Amazon.PowerShell.Cmdlets.SUPCH
{
    /// <summary>
    /// CreateBillOfMaterialsImportJob creates an import job for the Product Bill Of Materials
    /// (BOM) entity. For information on the product_bom entity, see the AWS Supply Chain
    /// User Guide.
    /// 
    ///  
    /// <para>
    /// The CSV file must be located in an Amazon S3 location accessible to AWS Supply Chain.
    /// It is recommended to use the same Amazon S3 bucket created during your AWS Supply
    /// Chain instance creation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SUPCHBillOfMaterialsImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Supply Chain CreateBillOfMaterialsImportJob API operation.", Operation = new[] {"CreateBillOfMaterialsImportJob"}, SelectReturnType = typeof(Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSUPCHBillOfMaterialsImportJobCmdlet : AmazonSupplyChainClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The AWS Supply Chain instance identifier.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter S3uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI of the CSV file to be imported. The bucket must grant permissions for AWS
        /// Supply Chain to read the file.</para>
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
        public System.String S3uri { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token ensures the API request is only completed no more than once.
        /// This way, retrying the request will not trigger the operation multiple times. A client
        /// token is a unique, case-sensitive string of 33 to 128 ASCII characters. To make an
        /// idempotent API request, specify a client token in the request. You should not reuse
        /// the same client token for other requests. If you retry a successful request with the
        /// same client token, the request will succeed with no further actions being taken, and
        /// you will receive the same API response as the original successful request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobResponse).
        /// Specifying the name of a property of type Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SUPCHBillOfMaterialsImportJob (CreateBillOfMaterialsImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobResponse, NewSUPCHBillOfMaterialsImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3uri = this.S3uri;
            #if MODULAR
            if (this.S3uri == null && ParameterWasBound(nameof(this.S3uri)))
            {
                WriteWarning("You are passing $null as a value for parameter S3uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.S3uri != null)
            {
                request.S3uri = cmdletContext.S3uri;
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
        
        private Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobResponse CallAWSServiceOperation(IAmazonSupplyChain client, Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Supply Chain", "CreateBillOfMaterialsImportJob");
            try
            {
                return client.CreateBillOfMaterialsImportJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String InstanceId { get; set; }
            public System.String S3uri { get; set; }
            public System.Func<Amazon.SupplyChain.Model.CreateBillOfMaterialsImportJobResponse, NewSUPCHBillOfMaterialsImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
