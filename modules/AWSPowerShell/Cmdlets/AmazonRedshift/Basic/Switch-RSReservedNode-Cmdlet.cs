/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Exchanges a DC1 Reserved Node for a DC2 Reserved Node with no changes to the configuration
    /// (term, payment type, or number of nodes) and no additional costs.
    /// </summary>
    [Cmdlet("Switch", "RSReservedNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ReservedNode")]
    [AWSCmdlet("Calls the Amazon Redshift AcceptReservedNodeExchange API operation.", Operation = new[] {"AcceptReservedNodeExchange"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.ReservedNode",
        "This cmdlet returns a ReservedNode object.",
        "The service call response (type Amazon.Redshift.Model.AcceptReservedNodeExchangeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SwitchRSReservedNodeCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ReservedNodeId
        /// <summary>
        /// <para>
        /// <para>A string representing the node identifier of the DC1 Reserved Node to be exchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedNodeId { get; set; }
        #endregion
        
        #region Parameter TargetReservedNodeOfferingId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the DC2 Reserved Node offering to be used for the exchange.
        /// You can obtain the value for the parameter by calling <a>GetReservedNodeExchangeOfferings</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetReservedNodeOfferingId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReservedNodeId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Switch-RSReservedNode (AcceptReservedNodeExchange)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ReservedNodeId = this.ReservedNodeId;
            context.TargetReservedNodeOfferingId = this.TargetReservedNodeOfferingId;
            
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
            var request = new Amazon.Redshift.Model.AcceptReservedNodeExchangeRequest();
            
            if (cmdletContext.ReservedNodeId != null)
            {
                request.ReservedNodeId = cmdletContext.ReservedNodeId;
            }
            if (cmdletContext.TargetReservedNodeOfferingId != null)
            {
                request.TargetReservedNodeOfferingId = cmdletContext.TargetReservedNodeOfferingId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ExchangedReservedNode;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Redshift.Model.AcceptReservedNodeExchangeResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.AcceptReservedNodeExchangeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "AcceptReservedNodeExchange");
            try
            {
                #if DESKTOP
                return client.AcceptReservedNodeExchange(request);
                #elif CORECLR
                return client.AcceptReservedNodeExchangeAsync(request).GetAwaiter().GetResult();
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
            public System.String ReservedNodeId { get; set; }
            public System.String TargetReservedNodeOfferingId { get; set; }
        }
        
    }
}
