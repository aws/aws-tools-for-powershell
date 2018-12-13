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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Deletes a resolver rule. Before you can delete a resolver rule, you must disassociate
    /// it from all the VPCs that you associated the resolver rule with. For more infomation,
    /// see <a>DisassociateResolverRule</a>.
    /// </summary>
    [Cmdlet("Remove", "R53RResolverRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverRule")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver DeleteResolverRule API operation.", Operation = new[] {"DeleteResolverRule"})]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverRule",
        "This cmdlet returns a ResolverRule object.",
        "The service call response (type Amazon.Route53Resolver.Model.DeleteResolverRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveR53RResolverRuleCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        #region Parameter ResolverRuleId
        /// <summary>
        /// <para>
        /// <para>The ID of the resolver rule that you want to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResolverRuleId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResolverRuleId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53RResolverRule (DeleteResolverRule)"))
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
            
            context.ResolverRuleId = this.ResolverRuleId;
            
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
            var request = new Amazon.Route53Resolver.Model.DeleteResolverRuleRequest();
            
            if (cmdletContext.ResolverRuleId != null)
            {
                request.ResolverRuleId = cmdletContext.ResolverRuleId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ResolverRule;
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
        
        private Amazon.Route53Resolver.Model.DeleteResolverRuleResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.DeleteResolverRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "DeleteResolverRule");
            try
            {
                #if DESKTOP
                return client.DeleteResolverRule(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteResolverRuleAsync(request);
                return task.Result;
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
            public System.String ResolverRuleId { get; set; }
        }
        
    }
}
