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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// This operation replaces the current set of name servers for the domain with the specified
    /// set of name servers. If you use Amazon Route 53 as your DNS service, specify the four
    /// name servers in the delegation set for the hosted zone for the domain.
    /// 
    ///  
    /// <para>
    /// If successful, this operation returns an operation ID that you can use to track the
    /// progress and completion of the action. If the request is not completed successfully,
    /// the domain registrant will be notified by email.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53DDomainNameserver", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains UpdateDomainNameservers API operation.", Operation = new[] {"UpdateDomainNameservers"}, LegacyAlias="Update-R53DDomainNameservers")]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Route53Domains.Model.UpdateDomainNameserversResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateR53DDomainNameserverCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to change name servers for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter FIAuthKey
        /// <summary>
        /// <para>
        /// <para>The authorization key for .fi domains</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This property is deprecated")]
        public System.String FIAuthKey { get; set; }
        #endregion
        
        #region Parameter Nameserver
        /// <summary>
        /// <para>
        /// <para>A list of new name servers for the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Nameservers")]
        public Amazon.Route53Domains.Model.Nameserver[] Nameserver { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53DDomainNameserver (UpdateDomainNameservers)"))
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
            
            context.DomainName = this.DomainName;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FIAuthKey = this.FIAuthKey;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Nameserver != null)
            {
                context.Nameservers = new List<Amazon.Route53Domains.Model.Nameserver>(this.Nameserver);
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
            var request = new Amazon.Route53Domains.Model.UpdateDomainNameserversRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.FIAuthKey != null)
            {
                request.FIAuthKey = cmdletContext.FIAuthKey;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Nameservers != null)
            {
                request.Nameservers = cmdletContext.Nameservers;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.OperationId;
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
        
        private Amazon.Route53Domains.Model.UpdateDomainNameserversResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.UpdateDomainNameserversRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "UpdateDomainNameservers");
            try
            {
                #if DESKTOP
                return client.UpdateDomainNameservers(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateDomainNameserversAsync(request);
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
            public System.String DomainName { get; set; }
            [System.ObsoleteAttribute]
            public System.String FIAuthKey { get; set; }
            public List<Amazon.Route53Domains.Model.Nameserver> Nameservers { get; set; }
        }
        
    }
}
