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
using Amazon.Redshift;
using Amazon.Redshift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// From a datashare consumer account, remove association for the specified datashare.
    /// </summary>
    [Cmdlet("Remove", "RSDataShareConsumer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Redshift.Model.DisassociateDataShareConsumerResponse")]
    [AWSCmdlet("Calls the Amazon Redshift DisassociateDataShareConsumer API operation.", Operation = new[] {"DisassociateDataShareConsumer"}, SelectReturnType = typeof(Amazon.Redshift.Model.DisassociateDataShareConsumerResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.DisassociateDataShareConsumerResponse",
        "This cmdlet returns an Amazon.Redshift.Model.DisassociateDataShareConsumerResponse object containing multiple properties."
    )]
    public partial class RemoveRSDataShareConsumerCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConsumerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the consumer namespace that association for the
        /// datashare is removed from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConsumerArn { get; set; }
        #endregion
        
        #region Parameter ConsumerRegion
        /// <summary>
        /// <para>
        /// <para>From a datashare consumer account, removes association of a datashare from all the
        /// existing and future namespaces in the specified Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConsumerRegion { get; set; }
        #endregion
        
        #region Parameter DataShareArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the datashare to remove association for.</para>
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
        public System.String DataShareArn { get; set; }
        #endregion
        
        #region Parameter DisassociateEntireAccount
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether association for the datashare is removed from the entire
        /// account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisassociateEntireAccount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.DisassociateDataShareConsumerResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.DisassociateDataShareConsumerResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataShareArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RSDataShareConsumer (DisassociateDataShareConsumer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.DisassociateDataShareConsumerResponse, RemoveRSDataShareConsumerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConsumerArn = this.ConsumerArn;
            context.ConsumerRegion = this.ConsumerRegion;
            context.DataShareArn = this.DataShareArn;
            #if MODULAR
            if (this.DataShareArn == null && ParameterWasBound(nameof(this.DataShareArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataShareArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DisassociateEntireAccount = this.DisassociateEntireAccount;
            
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
            var request = new Amazon.Redshift.Model.DisassociateDataShareConsumerRequest();
            
            if (cmdletContext.ConsumerArn != null)
            {
                request.ConsumerArn = cmdletContext.ConsumerArn;
            }
            if (cmdletContext.ConsumerRegion != null)
            {
                request.ConsumerRegion = cmdletContext.ConsumerRegion;
            }
            if (cmdletContext.DataShareArn != null)
            {
                request.DataShareArn = cmdletContext.DataShareArn;
            }
            if (cmdletContext.DisassociateEntireAccount != null)
            {
                request.DisassociateEntireAccount = cmdletContext.DisassociateEntireAccount.Value;
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
        
        private Amazon.Redshift.Model.DisassociateDataShareConsumerResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.DisassociateDataShareConsumerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "DisassociateDataShareConsumer");
            try
            {
                return client.DisassociateDataShareConsumerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConsumerArn { get; set; }
            public System.String ConsumerRegion { get; set; }
            public System.String DataShareArn { get; set; }
            public System.Boolean? DisassociateEntireAccount { get; set; }
            public System.Func<Amazon.Redshift.Model.DisassociateDataShareConsumerResponse, RemoveRSDataShareConsumerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
