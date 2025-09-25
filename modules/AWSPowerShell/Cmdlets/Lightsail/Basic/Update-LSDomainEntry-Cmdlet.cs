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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Updates a domain recordset after it is created.
    /// 
    ///  
    /// <para>
    /// The <c>update domain entry</c> operation supports tag-based access control via resource
    /// tags applied to the resource identified by <c>domain name</c>. For more information,
    /// see the <a href="https://docs.aws.amazon.com/lightsail/latest/userguide/amazon-lightsail-controlling-access-using-tags">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LSDomainEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateDomainEntry API operation.", Operation = new[] {"UpdateDomainEntry"}, SelectReturnType = typeof(Amazon.Lightsail.Model.UpdateDomainEntryResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.UpdateDomainEntryResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.UpdateDomainEntryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateLSDomainEntryCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain recordset to update.</para>
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
        /// <para>When <c>true</c>, specifies whether the domain entry is an alias used by the Lightsail
        /// load balancer, Lightsail container service, Lightsail content delivery network (CDN)
        /// distribution, or another Amazon Web Services resource. You can include an alias (A
        /// type) record in your request, which points to the DNS name of a load balancer, container
        /// service, CDN distribution, or other Amazon Web Services resource and routes traffic
        /// to that resource.</para>
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
        /// <para>The target IP address (<c>192.0.2.0</c>), or AWS name server (<c>ns-111.awsdns-22.com.</c>).</para><para>For Lightsail load balancers, the value looks like <c>ab1234c56789c6b86aba6fb203d443bc-123456789.us-east-2.elb.amazonaws.com</c>.
        /// For Lightsail distributions, the value looks like <c>exampled1182ne.cloudfront.net</c>.
        /// For Lightsail container services, the value looks like <c>container-service-1.example23scljs.us-west-2.cs.amazonlightsail.com</c>.
        /// Be sure to also set <c>isAlias</c> to <c>true</c> when setting up an A record for
        /// a Lightsail load balancer, distribution, or container service.</para>
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
        /// locator (SRV), or text (TXT).</para><para>The following domain entry types can be used:</para><ul><li><para><c>A</c></para></li><li><para><c>AAAA</c></para></li><li><para><c>CNAME</c></para></li><li><para><c>MX</c></para></li><li><para><c>NS</c></para></li><li><para><c>SOA</c></para></li><li><para><c>SRV</c></para></li><li><para><c>TXT</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainEntry_Type { get; set; }
        #endregion
        
        #region Parameter DomainEntry_Option
        /// <summary>
        /// <para>
        /// <para>(Discontinued) The options for the domain entry.</para><note><para>In releases prior to November 29, 2017, this parameter was not included in the API
        /// response. It is now discontinued.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.UpdateDomainEntryResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.UpdateDomainEntryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSDomainEntry (UpdateDomainEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.UpdateDomainEntryResponse, UpdateLSDomainEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainEntry_Id = this.DomainEntry_Id;
            context.DomainEntry_IsAlias = this.DomainEntry_IsAlias;
            context.DomainEntry_Name = this.DomainEntry_Name;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DomainEntry_Option != null)
            {
                context.DomainEntry_Option = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DomainEntry_Option.Keys)
                {
                    context.DomainEntry_Option.Add((String)hashKey, (System.String)(this.DomainEntry_Option[hashKey]));
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
            var request = new Amazon.Lightsail.Model.UpdateDomainEntryRequest();
            
            
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
        
        private Amazon.Lightsail.Model.UpdateDomainEntryResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateDomainEntryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateDomainEntry");
            try
            {
                return client.UpdateDomainEntryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Lightsail.Model.UpdateDomainEntryResponse, UpdateLSDomainEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
