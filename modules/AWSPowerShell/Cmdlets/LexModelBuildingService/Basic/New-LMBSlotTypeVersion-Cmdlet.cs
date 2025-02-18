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
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;

namespace Amazon.PowerShell.Cmdlets.LMB
{
    /// <summary>
    /// Creates a new version of a slot type based on the <c>$LATEST</c> version of the specified
    /// slot type. If the <c>$LATEST</c> version of this resource has not changed since the
    /// last version that you created, Amazon Lex doesn't create a new version. It returns
    /// the last version that you created. 
    /// 
    ///  <note><para>
    /// You can update only the <c>$LATEST</c> version of a slot type. You can't update the
    /// numbered versions that you create with the <c>CreateSlotTypeVersion</c> operation.
    /// </para></note><para>
    /// When you create a version of a slot type, Amazon Lex sets the version to 1. Subsequent
    /// versions increment by 1. For more information, see <a>versioning-intro</a>. 
    /// </para><para>
    /// This operation requires permissions for the <c>lex:CreateSlotTypeVersion</c> action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LMBSlotTypeVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building Service CreateSlotTypeVersion API operation.", Operation = new[] {"CreateSlotTypeVersion"}, SelectReturnType = typeof(Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionResponse))]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionResponse",
        "This cmdlet returns an Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionResponse object containing multiple properties."
    )]
    public partial class NewLMBSlotTypeVersionCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Checksum
        /// <summary>
        /// <para>
        /// <para>Checksum for the <c>$LATEST</c> version of the slot type that you want to publish.
        /// If you specify a checksum and the <c>$LATEST</c> version of the slot type has a different
        /// checksum, Amazon Lex returns a <c>PreconditionFailedException</c> exception and doesn't
        /// publish the new version. If you don't specify a checksum, Amazon Lex publishes the
        /// <c>$LATEST</c> version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Checksum { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the slot type that you want to create a new version for. The name is case
        /// sensitive. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionResponse).
        /// Specifying the name of a property of type Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMBSlotTypeVersion (CreateSlotTypeVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionResponse, NewLMBSlotTypeVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Checksum = this.Checksum;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionRequest();
            
            if (cmdletContext.Checksum != null)
            {
                request.Checksum = cmdletContext.Checksum;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "CreateSlotTypeVersion");
            try
            {
                return client.CreateSlotTypeVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Checksum { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.LexModelBuildingService.Model.CreateSlotTypeVersionResponse, NewLMBSlotTypeVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
