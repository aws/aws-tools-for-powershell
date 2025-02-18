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
using Amazon.VoiceID;
using Amazon.VoiceID.Model;

namespace Amazon.PowerShell.Cmdlets.VID
{
    /// <summary>
    /// Disassociates the fraudsters from the watchlist specified. Voice ID always expects
    /// a fraudster to be a part of at least one watchlist. If you try to disassociate a fraudster
    /// from its only watchlist, a <c>ValidationException</c> is thrown.
    /// </summary>
    [Cmdlet("Remove", "VIDFraudsterAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.VoiceID.Model.Fraudster")]
    [AWSCmdlet("Calls the Amazon Voice ID DisassociateFraudster API operation.", Operation = new[] {"DisassociateFraudster"}, SelectReturnType = typeof(Amazon.VoiceID.Model.DisassociateFraudsterResponse))]
    [AWSCmdletOutput("Amazon.VoiceID.Model.Fraudster or Amazon.VoiceID.Model.DisassociateFraudsterResponse",
        "This cmdlet returns an Amazon.VoiceID.Model.Fraudster object.",
        "The service call response (type Amazon.VoiceID.Model.DisassociateFraudsterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveVIDFraudsterAssociationCmdlet : AmazonVoiceIDClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The identifier of the domain that contains the fraudster.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter FraudsterId
        /// <summary>
        /// <para>
        /// <para>The identifier of the fraudster to be disassociated from the watchlist.</para>
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
        public System.String FraudsterId { get; set; }
        #endregion
        
        #region Parameter WatchlistId
        /// <summary>
        /// <para>
        /// <para>The identifier of the watchlist that you want to disassociate from the fraudster.</para>
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
        public System.String WatchlistId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Fraudster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VoiceID.Model.DisassociateFraudsterResponse).
        /// Specifying the name of a property of type Amazon.VoiceID.Model.DisassociateFraudsterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Fraudster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WatchlistId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-VIDFraudsterAssociation (DisassociateFraudster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VoiceID.Model.DisassociateFraudsterResponse, RemoveVIDFraudsterAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FraudsterId = this.FraudsterId;
            #if MODULAR
            if (this.FraudsterId == null && ParameterWasBound(nameof(this.FraudsterId)))
            {
                WriteWarning("You are passing $null as a value for parameter FraudsterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WatchlistId = this.WatchlistId;
            #if MODULAR
            if (this.WatchlistId == null && ParameterWasBound(nameof(this.WatchlistId)))
            {
                WriteWarning("You are passing $null as a value for parameter WatchlistId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VoiceID.Model.DisassociateFraudsterRequest();
            
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.FraudsterId != null)
            {
                request.FraudsterId = cmdletContext.FraudsterId;
            }
            if (cmdletContext.WatchlistId != null)
            {
                request.WatchlistId = cmdletContext.WatchlistId;
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
        
        private Amazon.VoiceID.Model.DisassociateFraudsterResponse CallAWSServiceOperation(IAmazonVoiceID client, Amazon.VoiceID.Model.DisassociateFraudsterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Voice ID", "DisassociateFraudster");
            try
            {
                return client.DisassociateFraudsterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.String FraudsterId { get; set; }
            public System.String WatchlistId { get; set; }
            public System.Func<Amazon.VoiceID.Model.DisassociateFraudsterResponse, RemoveVIDFraudsterAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Fraudster;
        }
        
    }
}
