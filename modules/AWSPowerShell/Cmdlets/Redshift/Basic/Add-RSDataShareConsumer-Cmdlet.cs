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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// From a datashare consumer account, associates a datashare with the account (AssociateEntireAccount)
    /// or the specified namespace (ConsumerArn). If you make this association, the consumer
    /// can consume the datashare.
    /// </summary>
    [Cmdlet("Add", "RSDataShareConsumer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.AssociateDataShareConsumerResponse")]
    [AWSCmdlet("Calls the Amazon Redshift AssociateDataShareConsumer API operation.", Operation = new[] {"AssociateDataShareConsumer"}, SelectReturnType = typeof(Amazon.Redshift.Model.AssociateDataShareConsumerResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.AssociateDataShareConsumerResponse",
        "This cmdlet returns an Amazon.Redshift.Model.AssociateDataShareConsumerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddRSDataShareConsumerCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter AssociateEntireAccount
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether the datashare is associated with the entire account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AssociateEntireAccount { get; set; }
        #endregion
        
        #region Parameter ConsumerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the consumer that is associated with the datashare.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConsumerArn { get; set; }
        #endregion
        
        #region Parameter ConsumerRegion
        /// <summary>
        /// <para>
        /// <para>From a datashare consumer account, associates a datashare with all existing and future
        /// namespaces in the specified Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConsumerRegion { get; set; }
        #endregion
        
        #region Parameter DataShareArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the datashare that the consumer is to use with the
        /// account or the namespace.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.AssociateDataShareConsumerResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.AssociateDataShareConsumerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataShareArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataShareArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataShareArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataShareArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-RSDataShareConsumer (AssociateDataShareConsumer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.AssociateDataShareConsumerResponse, AddRSDataShareConsumerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataShareArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssociateEntireAccount = this.AssociateEntireAccount;
            context.ConsumerArn = this.ConsumerArn;
            context.ConsumerRegion = this.ConsumerRegion;
            context.DataShareArn = this.DataShareArn;
            #if MODULAR
            if (this.DataShareArn == null && ParameterWasBound(nameof(this.DataShareArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataShareArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Redshift.Model.AssociateDataShareConsumerRequest();
            
            if (cmdletContext.AssociateEntireAccount != null)
            {
                request.AssociateEntireAccount = cmdletContext.AssociateEntireAccount.Value;
            }
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
        
        private Amazon.Redshift.Model.AssociateDataShareConsumerResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.AssociateDataShareConsumerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "AssociateDataShareConsumer");
            try
            {
                #if DESKTOP
                return client.AssociateDataShareConsumer(request);
                #elif CORECLR
                return client.AssociateDataShareConsumerAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AssociateEntireAccount { get; set; }
            public System.String ConsumerArn { get; set; }
            public System.String ConsumerRegion { get; set; }
            public System.String DataShareArn { get; set; }
            public System.Func<Amazon.Redshift.Model.AssociateDataShareConsumerResponse, AddRSDataShareConsumerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
