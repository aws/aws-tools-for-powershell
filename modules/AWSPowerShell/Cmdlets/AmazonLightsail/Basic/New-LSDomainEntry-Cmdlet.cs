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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates one of the following entry records associated with the domain: Address (A),
    /// canonical name (CNAME), mail exchanger (MX), name server (NS), start of authority
    /// (SOA), service locator (SRV), or text (TXT).
    /// 
    ///  
    /// <para>
    /// The <code>create domain entry</code> operation supports tag-based access control via
    /// resource tags applied to the resource identified by domainName. For more information,
    /// see the <a href="https://lightsail.aws.amazon.com/ls/docs/en/articles/amazon-lightsail-controlling-access-using-tags">Lightsail
    /// Dev Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSDomainEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateDomainEntry API operation.", Operation = new[] {"CreateDomainEntry"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a Operation object.",
        "The service call response (type Amazon.Lightsail.Model.CreateDomainEntryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSDomainEntryCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name (e.g., <code>example.com</code>) for which you want to create the
        /// domain entry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the domain recordset entry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainEntry_Id { get; set; }
        #endregion
        
        #region Parameter DomainEntry_IsAlias
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, specifies whether the domain entry is an alias used by the
        /// Lightsail load balancer. You can include an alias (A type) record in your request,
        /// which points to a load balancer DNS name and routes traffic to your load balancer</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DomainEntry_IsAlias { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Name
        /// <summary>
        /// <para>
        /// <para>The name of the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainEntry_Name { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Target
        /// <summary>
        /// <para>
        /// <para>The target AWS name server (e.g., <code>ns-111.awsdns-22.com.</code>).</para><para>For Lightsail load balancers, the value looks like <code>ab1234c56789c6b86aba6fb203d443bc-123456789.us-east-2.elb.amazonaws.com</code>.
        /// Be sure to also set <code>isAlias</code> to <code>true</code> when setting up an A
        /// record for a load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainEntry_Target { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Type
        /// <summary>
        /// <para>
        /// <para>The type of domain entry, such as address (A), canonical name (CNAME), mail exchanger
        /// (MX), name server (NS), start of authority (SOA), service locator (SRV), or text (TXT).</para><para>The following domain entry types can be used:</para><ul><li><para><code>A</code></para></li><li><para><code>CNAME</code></para></li><li><para><code>MX</code></para></li><li><para><code>NS</code></para></li><li><para><code>SOA</code></para></li><li><para><code>SRV</code></para></li><li><para><code>TXT</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainEntry_Type { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Option
        /// <summary>
        /// <para>
        /// <para>(Deprecated) The options for the domain entry.</para><note><para>In releases prior to November 29, 2017, this parameter was not included in the API
        /// response. It is now deprecated.</para></note>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("In releases prior to November 29, 2017, this parameter was not included in the AP" +
            "I response. It is now deprecated.")]
        [Alias("DomainEntry_Options")]
        public System.Collections.Hashtable DomainEntry_Option { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSDomainEntry (CreateDomainEntry)"))
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
            
            context.DomainEntry_Id = this.DomainEntry_Id;
            if (ParameterWasBound("DomainEntry_IsAlias"))
                context.DomainEntry_IsAlias = this.DomainEntry_IsAlias;
            context.DomainEntry_Name = this.DomainEntry_Name;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DomainEntry_Option != null)
            {
                context.DomainEntry_Options = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DomainEntry_Option.Keys)
                {
                    context.DomainEntry_Options.Add((String)hashKey, (String)(this.DomainEntry_Option[hashKey]));
                }
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainEntry_Target = this.DomainEntry_Target;
            context.DomainEntry_Type = this.DomainEntry_Type;
            context.DomainName = this.DomainName;
            
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
            var request = new Amazon.Lightsail.Model.CreateDomainEntryRequest();
            
            
             // populate DomainEntry
            bool requestDomainEntryIsNull = true;
            request.DomainEntry = new Amazon.Lightsail.Model.DomainEntry();
            System.String requestDomainEntry_domainEntry_Id = null;
            if (cmdletContext.DomainEntry_Id != null)
            {
                requestDomainEntry_domainEntry_Id = cmdletContext.DomainEntry_Id;
            }
            if (requestDomainEntry_domainEntry_Id != null)
            {
                request.DomainEntry.Id = requestDomainEntry_domainEntry_Id;
                requestDomainEntryIsNull = false;
            }
            System.Boolean? requestDomainEntry_domainEntry_IsAlias = null;
            if (cmdletContext.DomainEntry_IsAlias != null)
            {
                requestDomainEntry_domainEntry_IsAlias = cmdletContext.DomainEntry_IsAlias.Value;
            }
            if (requestDomainEntry_domainEntry_IsAlias != null)
            {
                request.DomainEntry.IsAlias = requestDomainEntry_domainEntry_IsAlias.Value;
                requestDomainEntryIsNull = false;
            }
            System.String requestDomainEntry_domainEntry_Name = null;
            if (cmdletContext.DomainEntry_Name != null)
            {
                requestDomainEntry_domainEntry_Name = cmdletContext.DomainEntry_Name;
            }
            if (requestDomainEntry_domainEntry_Name != null)
            {
                request.DomainEntry.Name = requestDomainEntry_domainEntry_Name;
                requestDomainEntryIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Dictionary<System.String, System.String> requestDomainEntry_domainEntry_Option = null;
            if (cmdletContext.DomainEntry_Options != null)
            {
                requestDomainEntry_domainEntry_Option = cmdletContext.DomainEntry_Options;
            }
            if (requestDomainEntry_domainEntry_Option != null)
            {
                request.DomainEntry.Options = requestDomainEntry_domainEntry_Option;
                requestDomainEntryIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestDomainEntry_domainEntry_Target = null;
            if (cmdletContext.DomainEntry_Target != null)
            {
                requestDomainEntry_domainEntry_Target = cmdletContext.DomainEntry_Target;
            }
            if (requestDomainEntry_domainEntry_Target != null)
            {
                request.DomainEntry.Target = requestDomainEntry_domainEntry_Target;
                requestDomainEntryIsNull = false;
            }
            System.String requestDomainEntry_domainEntry_Type = null;
            if (cmdletContext.DomainEntry_Type != null)
            {
                requestDomainEntry_domainEntry_Type = cmdletContext.DomainEntry_Type;
            }
            if (requestDomainEntry_domainEntry_Type != null)
            {
                request.DomainEntry.Type = requestDomainEntry_domainEntry_Type;
                requestDomainEntryIsNull = false;
            }
             // determine if request.DomainEntry should be set to null
            if (requestDomainEntryIsNull)
            {
                request.DomainEntry = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Operation;
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
        
        private Amazon.Lightsail.Model.CreateDomainEntryResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateDomainEntryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateDomainEntry");
            try
            {
                #if DESKTOP
                return client.CreateDomainEntry(request);
                #elif CORECLR
                return client.CreateDomainEntryAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainEntry_Id { get; set; }
            public System.Boolean? DomainEntry_IsAlias { get; set; }
            public System.String DomainEntry_Name { get; set; }
            [System.ObsoleteAttribute]
            public Dictionary<System.String, System.String> DomainEntry_Options { get; set; }
            public System.String DomainEntry_Target { get; set; }
            public System.String DomainEntry_Type { get; set; }
            public System.String DomainName { get; set; }
        }
        
    }
}
