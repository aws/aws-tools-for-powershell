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
    /// For DNS queries that originate in your VPCs, specifies which resolver endpoint the
    /// queries pass through, one domain name that you want to forward to your network, and
    /// the IP addresses of the DNS resolvers in your network.
    /// </summary>
    [Cmdlet("New", "R53RResolverRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverRule")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver CreateResolverRule API operation.", Operation = new[] {"CreateResolverRule"})]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverRule",
        "This cmdlet returns a ResolverRule object.",
        "The service call response (type Amazon.Route53Resolver.Model.CreateResolverRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53RResolverRuleCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed requests to be
        /// retried without the risk of executing the operation twice. <code>CreatorRequestId</code>
        /// can be any unique string, for example, a date/time stamp. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>DNS queries for this domain name are forwarded to the IP addresses that you specify
        /// in <code>TargetIps</code>. If a query matches multiple resolver rules (example.com
        /// and www.example.com), outbound DNS queries are routed using the resolver rule that
        /// contains the most specific domain name (www.example.com).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name that lets you easily find a rule in the Resolver dashboard in the
        /// Route 53 console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResolverEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the outbound resolver endpoint that you want to use to route DNS queries
        /// to the IP addresses that you specify in <code>TargetIps</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResolverEndpointId { get; set; }
        #endregion
        
        #region Parameter RuleType
        /// <summary>
        /// <para>
        /// <para>Specify <code>FORWARD</code>. Other resolver rule types aren't supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53Resolver.RuleTypeOption")]
        public Amazon.Route53Resolver.RuleTypeOption RuleType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of the tag keys and values that you want to associate with the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Route53Resolver.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetIp
        /// <summary>
        /// <para>
        /// <para>The IPs that you want Resolver to forward DNS queries to. You can specify only IPv4
        /// addresses. Separate IP addresses with a comma.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetIps")]
        public Amazon.Route53Resolver.Model.TargetAddress[] TargetIp { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53RResolverRule (CreateResolverRule)"))
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
            
            context.CreatorRequestId = this.CreatorRequestId;
            context.DomainName = this.DomainName;
            context.Name = this.Name;
            context.ResolverEndpointId = this.ResolverEndpointId;
            context.RuleType = this.RuleType;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Route53Resolver.Model.Tag>(this.Tag);
            }
            if (this.TargetIp != null)
            {
                context.TargetIps = new List<Amazon.Route53Resolver.Model.TargetAddress>(this.TargetIp);
            }
            
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
            var request = new Amazon.Route53Resolver.Model.CreateResolverRuleRequest();
            
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ResolverEndpointId != null)
            {
                request.ResolverEndpointId = cmdletContext.ResolverEndpointId;
            }
            if (cmdletContext.RuleType != null)
            {
                request.RuleType = cmdletContext.RuleType;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetIps != null)
            {
                request.TargetIps = cmdletContext.TargetIps;
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
        
        private Amazon.Route53Resolver.Model.CreateResolverRuleResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.CreateResolverRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "CreateResolverRule");
            try
            {
                #if DESKTOP
                return client.CreateResolverRule(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateResolverRuleAsync(request);
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
            public System.String CreatorRequestId { get; set; }
            public System.String DomainName { get; set; }
            public System.String Name { get; set; }
            public System.String ResolverEndpointId { get; set; }
            public Amazon.Route53Resolver.RuleTypeOption RuleType { get; set; }
            public List<Amazon.Route53Resolver.Model.Tag> Tags { get; set; }
            public List<Amazon.Route53Resolver.Model.TargetAddress> TargetIps { get; set; }
        }
        
    }
}
