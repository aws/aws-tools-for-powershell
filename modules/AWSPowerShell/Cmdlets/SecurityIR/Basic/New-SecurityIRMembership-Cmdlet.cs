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
using Amazon.SecurityIR;
using Amazon.SecurityIR.Model;

namespace Amazon.PowerShell.Cmdlets.SecurityIR
{
    /// <summary>
    /// Creates a new membership.
    /// </summary>
    [Cmdlet("New", "SecurityIRMembership", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Security Incident Response CreateMembership API operation.", Operation = new[] {"CreateMembership"}, SelectReturnType = typeof(Amazon.SecurityIR.Model.CreateMembershipResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecurityIR.Model.CreateMembershipResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityIR.Model.CreateMembershipResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSecurityIRMembershipCmdlet : AmazonSecurityIRClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CoverEntireOrganization
        /// <summary>
        /// <para>
        /// <para>The <c>coverEntireOrganization</c> parameter is a boolean flag that determines whether
        /// the membership should be applied to the entire Amazon Web Services Organization. When
        /// set to true, the membership will be created for all accounts within the organization.
        /// When set to false, the membership will only be created for specified accounts. </para><para>This parameter is optional. If not specified, the default value is false.</para><ul><li><para>If set to <i>true</i>: The membership will automatically include all existing and
        /// future accounts in the Amazon Web Services Organization. </para></li><li><para>If set to <i>false</i>: The membership will only apply to explicitly specified accounts.
        /// </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CoverEntireOrganization { get; set; }
        #endregion
        
        #region Parameter IncidentResponseTeam
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateMembership to add customer incident
        /// response team members and trusted partners to the membership. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.SecurityIR.Model.IncidentResponder[] IncidentResponseTeam { get; set; }
        #endregion
        
        #region Parameter MembershipName
        /// <summary>
        /// <para>
        /// <para>Required element used in combination with CreateMembership to create a name for the
        /// membership.</para>
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
        public System.String MembershipName { get; set; }
        #endregion
        
        #region Parameter OptInFeature
        /// <summary>
        /// <para>
        /// <para>Optional element to enable the monitoring and investigation opt-in features for the
        /// service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OptInFeatures")]
        public Amazon.SecurityIR.Model.OptInFeature[] OptInFeature { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional element for customer configured tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para><note><para>The <c>clientToken</c> field is an idempotency key used to ensure that repeated attempts
        /// for a single action will be ignored by the server during retries. A caller supplied
        /// unique ID (typically a UUID) should be provided. </para></note></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MembershipId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityIR.Model.CreateMembershipResponse).
        /// Specifying the name of a property of type Amazon.SecurityIR.Model.CreateMembershipResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MembershipId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MembershipName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MembershipName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MembershipName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SecurityIRMembership (CreateMembership)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityIR.Model.CreateMembershipResponse, NewSecurityIRMembershipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MembershipName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.CoverEntireOrganization = this.CoverEntireOrganization;
            if (this.IncidentResponseTeam != null)
            {
                context.IncidentResponseTeam = new List<Amazon.SecurityIR.Model.IncidentResponder>(this.IncidentResponseTeam);
            }
            #if MODULAR
            if (this.IncidentResponseTeam == null && ParameterWasBound(nameof(this.IncidentResponseTeam)))
            {
                WriteWarning("You are passing $null as a value for parameter IncidentResponseTeam which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipName = this.MembershipName;
            #if MODULAR
            if (this.MembershipName == null && ParameterWasBound(nameof(this.MembershipName)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OptInFeature != null)
            {
                context.OptInFeature = new List<Amazon.SecurityIR.Model.OptInFeature>(this.OptInFeature);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.SecurityIR.Model.CreateMembershipRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CoverEntireOrganization != null)
            {
                request.CoverEntireOrganization = cmdletContext.CoverEntireOrganization.Value;
            }
            if (cmdletContext.IncidentResponseTeam != null)
            {
                request.IncidentResponseTeam = cmdletContext.IncidentResponseTeam;
            }
            if (cmdletContext.MembershipName != null)
            {
                request.MembershipName = cmdletContext.MembershipName;
            }
            if (cmdletContext.OptInFeature != null)
            {
                request.OptInFeatures = cmdletContext.OptInFeature;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SecurityIR.Model.CreateMembershipResponse CallAWSServiceOperation(IAmazonSecurityIR client, Amazon.SecurityIR.Model.CreateMembershipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Security Incident Response", "CreateMembership");
            try
            {
                #if DESKTOP
                return client.CreateMembership(request);
                #elif CORECLR
                return client.CreateMembershipAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Boolean? CoverEntireOrganization { get; set; }
            public List<Amazon.SecurityIR.Model.IncidentResponder> IncidentResponseTeam { get; set; }
            public System.String MembershipName { get; set; }
            public List<Amazon.SecurityIR.Model.OptInFeature> OptInFeature { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SecurityIR.Model.CreateMembershipResponse, NewSecurityIRMembershipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MembershipId;
        }
        
    }
}
