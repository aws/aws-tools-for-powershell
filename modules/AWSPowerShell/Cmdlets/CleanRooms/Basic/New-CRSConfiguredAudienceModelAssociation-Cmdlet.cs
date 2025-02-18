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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Provides the details necessary to create a configured audience model association.
    /// </summary>
    [Cmdlet("New", "CRSConfiguredAudienceModelAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.ConfiguredAudienceModelAssociation")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateConfiguredAudienceModelAssociation API operation.", Operation = new[] {"CreateConfiguredAudienceModelAssociation"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ConfiguredAudienceModelAssociation or Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ConfiguredAudienceModelAssociation object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRSConfiguredAudienceModelAssociationCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfiguredAudienceModelArn
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the configured audience model that you want to associate.</para>
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
        public System.String ConfiguredAudienceModelArn { get; set; }
        #endregion
        
        #region Parameter ConfiguredAudienceModelAssociationName
        /// <summary>
        /// <para>
        /// <para>The name of the configured audience model association.</para>
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
        public System.String ConfiguredAudienceModelAssociationName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the configured audience model association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ManageResourcePolicy
        /// <summary>
        /// <para>
        /// <para>When <c>TRUE</c>, indicates that the resource policy for the configured audience model
        /// resource being associated is configured for Clean Rooms to manage permissions related
        /// to the given collaboration. When <c>FALSE</c>, indicates that the configured audience
        /// model resource owner will manage permissions related to the given collaboration.</para><para>Setting this to <c>TRUE</c> requires you to have permissions to create, update, and
        /// delete the resource policy for the <c>cleanrooms-ml</c> resource when you call the
        /// <a>DeleteConfiguredAudienceModelAssociation</a> resource. In addition, if you are
        /// the collaboration creator and specify <c>TRUE</c>, you must have the same permissions
        /// when you call the <a>DeleteMember</a> and <a>DeleteCollaboration</a> APIs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ManageResourcePolicies")]
        public System.Boolean? ManageResourcePolicy { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for one of your memberships for a collaboration. The configured
        /// audience model is associated to the collaboration that this membership belongs to.
        /// Accepts a membership ID.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional label that you can assign to a resource when you create it. Each tag consists
        /// of a key and an optional value, both of which you define. When you use tagging, you
        /// can also use tag-based access control in IAM policies to control access to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfiguredAudienceModelAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfiguredAudienceModelAssociation";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfiguredAudienceModelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSConfiguredAudienceModelAssociation (CreateConfiguredAudienceModelAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationResponse, NewCRSConfiguredAudienceModelAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfiguredAudienceModelArn = this.ConfiguredAudienceModelArn;
            #if MODULAR
            if (this.ConfiguredAudienceModelArn == null && ParameterWasBound(nameof(this.ConfiguredAudienceModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredAudienceModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfiguredAudienceModelAssociationName = this.ConfiguredAudienceModelAssociationName;
            #if MODULAR
            if (this.ConfiguredAudienceModelAssociationName == null && ParameterWasBound(nameof(this.ConfiguredAudienceModelAssociationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredAudienceModelAssociationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.ManageResourcePolicy = this.ManageResourcePolicy;
            #if MODULAR
            if (this.ManageResourcePolicy == null && ParameterWasBound(nameof(this.ManageResourcePolicy)))
            {
                WriteWarning("You are passing $null as a value for parameter ManageResourcePolicy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationRequest();
            
            if (cmdletContext.ConfiguredAudienceModelArn != null)
            {
                request.ConfiguredAudienceModelArn = cmdletContext.ConfiguredAudienceModelArn;
            }
            if (cmdletContext.ConfiguredAudienceModelAssociationName != null)
            {
                request.ConfiguredAudienceModelAssociationName = cmdletContext.ConfiguredAudienceModelAssociationName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ManageResourcePolicy != null)
            {
                request.ManageResourcePolicies = cmdletContext.ManageResourcePolicy.Value;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
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
        
        private Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateConfiguredAudienceModelAssociation");
            try
            {
                return client.CreateConfiguredAudienceModelAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfiguredAudienceModelArn { get; set; }
            public System.String ConfiguredAudienceModelAssociationName { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? ManageResourcePolicy { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateConfiguredAudienceModelAssociationResponse, NewCRSConfiguredAudienceModelAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfiguredAudienceModelAssociation;
        }
        
    }
}
