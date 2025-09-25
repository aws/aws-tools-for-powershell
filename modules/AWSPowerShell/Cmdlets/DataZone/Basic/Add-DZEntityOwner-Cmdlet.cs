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
using Amazon.DataZone;
using Amazon.DataZone.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Adds the owner of an entity (a domain unit).
    /// </summary>
    [Cmdlet("Add", "DZEntityOwner", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon DataZone AddEntityOwner API operation.", Operation = new[] {"AddEntityOwner"}, SelectReturnType = typeof(Amazon.DataZone.Model.AddEntityOwnerResponse))]
    [AWSCmdletOutput("None or Amazon.DataZone.Model.AddEntityOwnerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataZone.Model.AddEntityOwnerResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddDZEntityOwnerCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the domain in which you want to add the entity owner.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter EntityIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the entity to which you want to add an owner.</para>
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
        public System.String EntityIdentifier { get; set; }
        #endregion
        
        #region Parameter EntityType
        /// <summary>
        /// <para>
        /// <para>The type of an entity.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataZone.DataZoneEntityType")]
        public Amazon.DataZone.DataZoneEntityType EntityType { get; set; }
        #endregion
        
        #region Parameter Group_GroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the domain unit owners group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Owner_Group_GroupIdentifier")]
        public System.String Group_GroupIdentifier { get; set; }
        #endregion
        
        #region Parameter User_UserIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the owner user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Owner_User_UserIdentifier")]
        public System.String User_UserIdentifier { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.AddEntityOwnerResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EntityIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DZEntityOwner (AddEntityOwner)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.AddEntityOwnerResponse, AddDZEntityOwnerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntityIdentifier = this.EntityIdentifier;
            #if MODULAR
            if (this.EntityIdentifier == null && ParameterWasBound(nameof(this.EntityIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntityType = this.EntityType;
            #if MODULAR
            if (this.EntityType == null && ParameterWasBound(nameof(this.EntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Group_GroupIdentifier = this.Group_GroupIdentifier;
            context.User_UserIdentifier = this.User_UserIdentifier;
            
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
            var request = new Amazon.DataZone.Model.AddEntityOwnerRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EntityIdentifier != null)
            {
                request.EntityIdentifier = cmdletContext.EntityIdentifier;
            }
            if (cmdletContext.EntityType != null)
            {
                request.EntityType = cmdletContext.EntityType;
            }
            
             // populate Owner
            var requestOwnerIsNull = true;
            request.Owner = new Amazon.DataZone.Model.OwnerProperties();
            Amazon.DataZone.Model.OwnerGroupProperties requestOwner_owner_Group = null;
            
             // populate Group
            var requestOwner_owner_GroupIsNull = true;
            requestOwner_owner_Group = new Amazon.DataZone.Model.OwnerGroupProperties();
            System.String requestOwner_owner_Group_group_GroupIdentifier = null;
            if (cmdletContext.Group_GroupIdentifier != null)
            {
                requestOwner_owner_Group_group_GroupIdentifier = cmdletContext.Group_GroupIdentifier;
            }
            if (requestOwner_owner_Group_group_GroupIdentifier != null)
            {
                requestOwner_owner_Group.GroupIdentifier = requestOwner_owner_Group_group_GroupIdentifier;
                requestOwner_owner_GroupIsNull = false;
            }
             // determine if requestOwner_owner_Group should be set to null
            if (requestOwner_owner_GroupIsNull)
            {
                requestOwner_owner_Group = null;
            }
            if (requestOwner_owner_Group != null)
            {
                request.Owner.Group = requestOwner_owner_Group;
                requestOwnerIsNull = false;
            }
            Amazon.DataZone.Model.OwnerUserProperties requestOwner_owner_User = null;
            
             // populate User
            var requestOwner_owner_UserIsNull = true;
            requestOwner_owner_User = new Amazon.DataZone.Model.OwnerUserProperties();
            System.String requestOwner_owner_User_user_UserIdentifier = null;
            if (cmdletContext.User_UserIdentifier != null)
            {
                requestOwner_owner_User_user_UserIdentifier = cmdletContext.User_UserIdentifier;
            }
            if (requestOwner_owner_User_user_UserIdentifier != null)
            {
                requestOwner_owner_User.UserIdentifier = requestOwner_owner_User_user_UserIdentifier;
                requestOwner_owner_UserIsNull = false;
            }
             // determine if requestOwner_owner_User should be set to null
            if (requestOwner_owner_UserIsNull)
            {
                requestOwner_owner_User = null;
            }
            if (requestOwner_owner_User != null)
            {
                request.Owner.User = requestOwner_owner_User;
                requestOwnerIsNull = false;
            }
             // determine if request.Owner should be set to null
            if (requestOwnerIsNull)
            {
                request.Owner = null;
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
        
        private Amazon.DataZone.Model.AddEntityOwnerResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.AddEntityOwnerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "AddEntityOwner");
            try
            {
                return client.AddEntityOwnerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainIdentifier { get; set; }
            public System.String EntityIdentifier { get; set; }
            public Amazon.DataZone.DataZoneEntityType EntityType { get; set; }
            public System.String Group_GroupIdentifier { get; set; }
            public System.String User_UserIdentifier { get; set; }
            public System.Func<Amazon.DataZone.Model.AddEntityOwnerResponse, AddDZEntityOwnerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
