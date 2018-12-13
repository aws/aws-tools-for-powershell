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
    /// Removes the association between a specified resolver rule and a specified VPC.
    /// 
    ///  <important><para>
    /// If you disassociate a resolver rule from a VPC, Resolver stops forwarding DNS queries
    /// for the domain name that you specified in the resolver rule. 
    /// </para></important>
    /// </summary>
    [Cmdlet("Remove", "R53RResolverRuleAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverRuleAssociation")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver DisassociateResolverRule API operation.", Operation = new[] {"DisassociateResolverRule"})]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverRuleAssociation",
        "This cmdlet returns a ResolverRuleAssociation object.",
        "The service call response (type Amazon.Route53Resolver.Model.DisassociateResolverRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveR53RResolverRuleAssociationCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        #region Parameter ResolverRuleId
        /// <summary>
        /// <para>
        /// <para>The ID of the resolver rule that you want to disassociate from the specified VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResolverRuleId { get; set; }
        #endregion
        
        #region Parameter VPCId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC that you want to disassociate the resolver rule from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VPCId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53RResolverRuleAssociation (DisassociateResolverRule)"))
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
            context.VPCId = this.VPCId;
            
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
            var request = new Amazon.Route53Resolver.Model.DisassociateResolverRuleRequest();
            
            if (cmdletContext.ResolverRuleId != null)
            {
                request.ResolverRuleId = cmdletContext.ResolverRuleId;
            }
            if (cmdletContext.VPCId != null)
            {
                request.VPCId = cmdletContext.VPCId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ResolverRuleAssociation;
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
        
        private Amazon.Route53Resolver.Model.DisassociateResolverRuleResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.DisassociateResolverRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "DisassociateResolverRule");
            try
            {
                #if DESKTOP
                return client.DisassociateResolverRule(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DisassociateResolverRuleAsync(request);
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
            public System.String VPCId { get; set; }
        }
        
    }
}
