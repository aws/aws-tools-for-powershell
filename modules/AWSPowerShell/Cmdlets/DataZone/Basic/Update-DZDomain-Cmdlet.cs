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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Updates a Amazon DataZone domain.
    /// </summary>
    [Cmdlet("Update", "DZDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.UpdateDomainResponse")]
    [AWSCmdlet("Calls the Amazon DataZone UpdateDomain API operation.", Operation = new[] {"UpdateDomain"}, SelectReturnType = typeof(Amazon.DataZone.Model.UpdateDomainResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.UpdateDomainResponse",
        "This cmdlet returns an Amazon.DataZone.Model.UpdateDomainResponse object containing multiple properties."
    )]
    public partial class UpdateDZDomainCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to be updated as part of the <c>UpdateDomain</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainExecutionRole
        /// <summary>
        /// <para>
        /// <para>The domain execution role to be updated as part of the <c>UpdateDomain</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainExecutionRole { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services domain that is to be updated.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name to be updated as part of the <c>UpdateDomain</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The service role of the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter SingleSignOn_Type
        /// <summary>
        /// <para>
        /// <para>The type of single sign-on in Amazon DataZone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.AuthType")]
        public Amazon.DataZone.AuthType SingleSignOn_Type { get; set; }
        #endregion
        
        #region Parameter SingleSignOn_UserAssignment
        /// <summary>
        /// <para>
        /// <para>The single sign-on user assignment in Amazon DataZone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.UserAssignment")]
        public Amazon.DataZone.UserAssignment SingleSignOn_UserAssignment { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that is provided to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.UpdateDomainResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.UpdateDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DZDomain (UpdateDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.UpdateDomainResponse, UpdateDZDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DomainExecutionRole = this.DomainExecutionRole;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.ServiceRole = this.ServiceRole;
            context.SingleSignOn_Type = this.SingleSignOn_Type;
            context.SingleSignOn_UserAssignment = this.SingleSignOn_UserAssignment;
            
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
            var request = new Amazon.DataZone.Model.UpdateDomainRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainExecutionRole != null)
            {
                request.DomainExecutionRole = cmdletContext.DomainExecutionRole;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
            }
            
             // populate SingleSignOn
            var requestSingleSignOnIsNull = true;
            request.SingleSignOn = new Amazon.DataZone.Model.SingleSignOn();
            Amazon.DataZone.AuthType requestSingleSignOn_singleSignOn_Type = null;
            if (cmdletContext.SingleSignOn_Type != null)
            {
                requestSingleSignOn_singleSignOn_Type = cmdletContext.SingleSignOn_Type;
            }
            if (requestSingleSignOn_singleSignOn_Type != null)
            {
                request.SingleSignOn.Type = requestSingleSignOn_singleSignOn_Type;
                requestSingleSignOnIsNull = false;
            }
            Amazon.DataZone.UserAssignment requestSingleSignOn_singleSignOn_UserAssignment = null;
            if (cmdletContext.SingleSignOn_UserAssignment != null)
            {
                requestSingleSignOn_singleSignOn_UserAssignment = cmdletContext.SingleSignOn_UserAssignment;
            }
            if (requestSingleSignOn_singleSignOn_UserAssignment != null)
            {
                request.SingleSignOn.UserAssignment = requestSingleSignOn_singleSignOn_UserAssignment;
                requestSingleSignOnIsNull = false;
            }
             // determine if request.SingleSignOn should be set to null
            if (requestSingleSignOnIsNull)
            {
                request.SingleSignOn = null;
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
        
        private Amazon.DataZone.Model.UpdateDomainResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.UpdateDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "UpdateDomain");
            try
            {
                #if DESKTOP
                return client.UpdateDomain(request);
                #elif CORECLR
                return client.UpdateDomainAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DomainExecutionRole { get; set; }
            public System.String Identifier { get; set; }
            public System.String Name { get; set; }
            public System.String ServiceRole { get; set; }
            public Amazon.DataZone.AuthType SingleSignOn_Type { get; set; }
            public Amazon.DataZone.UserAssignment SingleSignOn_UserAssignment { get; set; }
            public System.Func<Amazon.DataZone.Model.UpdateDomainResponse, UpdateDZDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
