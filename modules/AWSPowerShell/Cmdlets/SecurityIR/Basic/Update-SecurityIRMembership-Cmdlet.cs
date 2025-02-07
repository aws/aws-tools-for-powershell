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
    /// Grants access to UpdateMembership to change membership configuration.
    /// </summary>
    [Cmdlet("Update", "SecurityIRMembership", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Security Incident Response UpdateMembership API operation.", Operation = new[] {"UpdateMembership"}, SelectReturnType = typeof(Amazon.SecurityIR.Model.UpdateMembershipResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityIR.Model.UpdateMembershipResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityIR.Model.UpdateMembershipResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSecurityIRMembershipCmdlet : AmazonSecurityIRClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IncidentResponseTeam
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateMembership to update the membership name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityIR.Model.IncidentResponder[] IncidentResponseTeam { get; set; }
        #endregion
        
        #region Parameter MembershipId
        /// <summary>
        /// <para>
        /// <para>Required element for UpdateMembership to identify the membership to update.</para>
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
        public System.String MembershipId { get; set; }
        #endregion
        
        #region Parameter MembershipName
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateMembership to update the membership name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MembershipName { get; set; }
        #endregion
        
        #region Parameter OptInFeature
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateMembership to enable or disable opt-in features for the
        /// service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OptInFeatures")]
        public Amazon.SecurityIR.Model.OptInFeature[] OptInFeature { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityIR.Model.UpdateMembershipResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MembershipId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MembershipId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MembershipId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SecurityIRMembership (UpdateMembership)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityIR.Model.UpdateMembershipResponse, UpdateSecurityIRMembershipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MembershipId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.IncidentResponseTeam != null)
            {
                context.IncidentResponseTeam = new List<Amazon.SecurityIR.Model.IncidentResponder>(this.IncidentResponseTeam);
            }
            context.MembershipId = this.MembershipId;
            #if MODULAR
            if (this.MembershipId == null && ParameterWasBound(nameof(this.MembershipId)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipName = this.MembershipName;
            if (this.OptInFeature != null)
            {
                context.OptInFeature = new List<Amazon.SecurityIR.Model.OptInFeature>(this.OptInFeature);
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
            var request = new Amazon.SecurityIR.Model.UpdateMembershipRequest();
            
            if (cmdletContext.IncidentResponseTeam != null)
            {
                request.IncidentResponseTeam = cmdletContext.IncidentResponseTeam;
            }
            if (cmdletContext.MembershipId != null)
            {
                request.MembershipId = cmdletContext.MembershipId;
            }
            if (cmdletContext.MembershipName != null)
            {
                request.MembershipName = cmdletContext.MembershipName;
            }
            if (cmdletContext.OptInFeature != null)
            {
                request.OptInFeatures = cmdletContext.OptInFeature;
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
        
        private Amazon.SecurityIR.Model.UpdateMembershipResponse CallAWSServiceOperation(IAmazonSecurityIR client, Amazon.SecurityIR.Model.UpdateMembershipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Security Incident Response", "UpdateMembership");
            try
            {
                #if DESKTOP
                return client.UpdateMembership(request);
                #elif CORECLR
                return client.UpdateMembershipAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityIR.Model.IncidentResponder> IncidentResponseTeam { get; set; }
            public System.String MembershipId { get; set; }
            public System.String MembershipName { get; set; }
            public List<Amazon.SecurityIR.Model.OptInFeature> OptInFeature { get; set; }
            public System.Func<Amazon.SecurityIR.Model.UpdateMembershipResponse, UpdateSecurityIRMembershipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
