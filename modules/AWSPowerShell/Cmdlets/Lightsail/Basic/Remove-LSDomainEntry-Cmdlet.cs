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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Deletes a specific domain entry.
    /// 
    ///  
    /// <para>
    /// The <code>delete domain entry</code> operation supports tag-based access control via
    /// resource tags applied to the resource identified by <code>domain name</code>. For
    /// more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-controlling-access-using-tags">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "LSDomainEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail DeleteDomainEntry API operation.", Operation = new[] {"DeleteDomainEntry"}, SelectReturnType = typeof(Amazon.Lightsail.Model.DeleteDomainEntryResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.DeleteDomainEntryResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.Operation object.",
        "The service call response (type Amazon.Lightsail.Model.DeleteDomainEntryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveLSDomainEntryCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain entry to delete.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the domain recordset entry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainEntry_Id { get; set; }
        #endregion
        
        #region Parameter DomainEntry_IsAlias
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, specifies whether the domain entry is an alias used by the
        /// Lightsail load balancer. You can include an alias (A type) record in your request,
        /// which points to a load balancer DNS name and routes traffic to your load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DomainEntry_IsAlias { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Name
        /// <summary>
        /// <para>
        /// <para>The name of the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainEntry_Name { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Target
        /// <summary>
        /// <para>
        /// <para>The target IP address (e.g., <code>192.0.2.0</code>), or AWS name server (e.g., <code>ns-111.awsdns-22.com.</code>).</para><para>For Lightsail load balancers, the value looks like <code>ab1234c56789c6b86aba6fb203d443bc-123456789.us-east-2.elb.amazonaws.com</code>.
        /// For Lightsail distributions, the value looks like <code>exampled1182ne.cloudfront.net</code>.
        /// For Lightsail container services, the value looks like <code>container-service-1.example23scljs.us-west-2.cs.amazonlightsail.com</code>.
        /// Be sure to also set <code>isAlias</code> to <code>true</code> when setting up an A
        /// record for a Lightsail load balancer, distribution, or container service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainEntry_Target { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Type
        /// <summary>
        /// <para>
        /// <para>The type of domain entry, such as address for IPv4 (A), address for IPv6 (AAAA), canonical
        /// name (CNAME), mail exchanger (MX), name server (NS), start of authority (SOA), service
        /// locator (SRV), or text (TXT).</para><para>The following domain entry types can be used:</para><ul><li><para><code>A</code></para></li><li><para><code>AAAA</code></para></li><li><para><code>CNAME</code></para></li><li><para><code>MX</code></para></li><li><para><code>NS</code></para></li><li><para><code>SOA</code></para></li><li><para><code>SRV</code></para></li><li><para><code>TXT</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("In releases prior to November 29, 2017, this parameter was not included in the API response. It is now deprecated.")]
        [Alias("DomainEntry_Options")]
        public System.Collections.Hashtable DomainEntry_Option { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.DeleteDomainEntryResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.DeleteDomainEntryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-LSDomainEntry (DeleteDomainEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.DeleteDomainEntryResponse, RemoveLSDomainEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainEntry_Id = this.DomainEntry_Id;
            context.DomainEntry_IsAlias = this.DomainEntry_IsAlias;
            context.DomainEntry_Name = this.DomainEntry_Name;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DomainEntry_Option != null)
            {
                context.DomainEntry_Option = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DomainEntry_Option.Keys)
                {
                    context.DomainEntry_Option.Add((String)hashKey, (String)(this.DomainEntry_Option[hashKey]));
                }
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainEntry_Target = this.DomainEntry_Target;
            context.DomainEntry_Type = this.DomainEntry_Type;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.DeleteDomainEntryRequest();
            
            
             // populate DomainEntry
            var requestDomainEntryIsNull = true;
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
            if (cmdletContext.DomainEntry_Option != null)
            {
                requestDomainEntry_domainEntry_Option = cmdletContext.DomainEntry_Option;
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
        
        private Amazon.Lightsail.Model.DeleteDomainEntryResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.DeleteDomainEntryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "DeleteDomainEntry");
            try
            {
                #if DESKTOP
                return client.DeleteDomainEntry(request);
                #elif CORECLR
                return client.DeleteDomainEntryAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> DomainEntry_Option { get; set; }
            public System.String DomainEntry_Target { get; set; }
            public System.String DomainEntry_Type { get; set; }
            public System.String DomainName { get; set; }
            public System.Func<Amazon.Lightsail.Model.DeleteDomainEntryResponse, RemoveLSDomainEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operation;
        }
        
    }
}
