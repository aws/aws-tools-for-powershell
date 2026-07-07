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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Creates an authorization code for the specified Connect Customer instance. The authorization
    /// code can be used to establish a session with scoped permissions defined by the specified
    /// scope parameters.
    /// </summary>
    [Cmdlet("New", "CONNAuthCode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateAuthCodeResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateAuthCode API operation.", Operation = new[] {"CreateAuthCode"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateAuthCodeResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateAuthCodeResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateAuthCodeResponse object containing multiple properties."
    )]
    public partial class NewCONNAuthCodeCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Scope_DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the Customer Profiles domain to scope the session to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Scope_DomainName { get; set; }
        #endregion
        
        #region Parameter Scope_EntityId
        /// <summary>
        /// <para>
        /// <para>The identifier of the entity to scope the session to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Scope_EntityId { get; set; }
        #endregion
        
        #region Parameter Scope_EntityType
        /// <summary>
        /// <para>
        /// <para>The type of entity to scope the session to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.AuthCodeEntityType")]
        public Amazon.Connect.AuthCodeEntityType Scope_EntityType { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter MaxSessionDurationMinute
        /// <summary>
        /// <para>
        /// <para>The maximum duration of the session, in minutes. Minimum value of 1440 (24 hours).
        /// Maximum value of 43200 (30 days). If no value is provided, the session will expire
        /// after 400 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxSessionDurationMinutes")]
        public System.Int32? MaxSessionDurationMinute { get; set; }
        #endregion
        
        #region Parameter Scope_SecurityProfileId
        /// <summary>
        /// <para>
        /// <para>The list of security profile identifiers to scope the session to. Maximum of 10 security
        /// profiles.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scope_SecurityProfileIds")]
        public System.String[] Scope_SecurityProfileId { get; set; }
        #endregion
        
        #region Parameter SessionInactivityDurationMinute
        /// <summary>
        /// <para>
        /// <para>The duration of inactivity, in minutes, after which the session expires. Minimum value
        /// of 1440 (24 hours). Maximum value of 20160 (14 days).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SessionInactivityDurationMinutes")]
        public System.Int32? SessionInactivityDurationMinute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateAuthCodeResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateAuthCodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNAuthCode (CreateAuthCode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateAuthCodeResponse, NewCONNAuthCodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxSessionDurationMinute = this.MaxSessionDurationMinute;
            context.Scope_DomainName = this.Scope_DomainName;
            context.Scope_EntityId = this.Scope_EntityId;
            context.Scope_EntityType = this.Scope_EntityType;
            #if MODULAR
            if (this.Scope_EntityType == null && ParameterWasBound(nameof(this.Scope_EntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope_EntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Scope_SecurityProfileId != null)
            {
                context.Scope_SecurityProfileId = new List<System.String>(this.Scope_SecurityProfileId);
            }
            context.SessionInactivityDurationMinute = this.SessionInactivityDurationMinute;
            #if MODULAR
            if (this.SessionInactivityDurationMinute == null && ParameterWasBound(nameof(this.SessionInactivityDurationMinute)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionInactivityDurationMinute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.CreateAuthCodeRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxSessionDurationMinute != null)
            {
                request.MaxSessionDurationMinutes = cmdletContext.MaxSessionDurationMinute.Value;
            }
            
             // populate Scope
            var requestScopeIsNull = true;
            request.Scope = new Amazon.Connect.Model.AuthScope();
            System.String requestScope_scope_DomainName = null;
            if (cmdletContext.Scope_DomainName != null)
            {
                requestScope_scope_DomainName = cmdletContext.Scope_DomainName;
            }
            if (requestScope_scope_DomainName != null)
            {
                request.Scope.DomainName = requestScope_scope_DomainName;
                requestScopeIsNull = false;
            }
            System.String requestScope_scope_EntityId = null;
            if (cmdletContext.Scope_EntityId != null)
            {
                requestScope_scope_EntityId = cmdletContext.Scope_EntityId;
            }
            if (requestScope_scope_EntityId != null)
            {
                request.Scope.EntityId = requestScope_scope_EntityId;
                requestScopeIsNull = false;
            }
            Amazon.Connect.AuthCodeEntityType requestScope_scope_EntityType = null;
            if (cmdletContext.Scope_EntityType != null)
            {
                requestScope_scope_EntityType = cmdletContext.Scope_EntityType;
            }
            if (requestScope_scope_EntityType != null)
            {
                request.Scope.EntityType = requestScope_scope_EntityType;
                requestScopeIsNull = false;
            }
            List<System.String> requestScope_scope_SecurityProfileId = null;
            if (cmdletContext.Scope_SecurityProfileId != null)
            {
                requestScope_scope_SecurityProfileId = cmdletContext.Scope_SecurityProfileId;
            }
            if (requestScope_scope_SecurityProfileId != null)
            {
                request.Scope.SecurityProfileIds = requestScope_scope_SecurityProfileId;
                requestScopeIsNull = false;
            }
             // determine if request.Scope should be set to null
            if (requestScopeIsNull)
            {
                request.Scope = null;
            }
            if (cmdletContext.SessionInactivityDurationMinute != null)
            {
                request.SessionInactivityDurationMinutes = cmdletContext.SessionInactivityDurationMinute.Value;
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
        
        private Amazon.Connect.Model.CreateAuthCodeResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateAuthCodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateAuthCode");
            try
            {
                return client.CreateAuthCodeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.Int32? MaxSessionDurationMinute { get; set; }
            public System.String Scope_DomainName { get; set; }
            public System.String Scope_EntityId { get; set; }
            public Amazon.Connect.AuthCodeEntityType Scope_EntityType { get; set; }
            public List<System.String> Scope_SecurityProfileId { get; set; }
            public System.Int32? SessionInactivityDurationMinute { get; set; }
            public System.Func<Amazon.Connect.Model.CreateAuthCodeResponse, NewCONNAuthCodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
