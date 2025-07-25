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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Provides the details that are necessary to update an ID namespace association.
    /// </summary>
    [Cmdlet("Update", "CRSIdNamespaceAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.IdNamespaceAssociation")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service UpdateIdNamespaceAssociation API operation.", Operation = new[] {"UpdateIdNamespaceAssociation"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.IdNamespaceAssociation or Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.IdNamespaceAssociation object.",
        "The service call response (type Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCRSIdNamespaceAssociationCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdMappingConfig_AllowUseAsDimensionColumn
        /// <summary>
        /// <para>
        /// <para>An indicator as to whether you can use your column as a dimension column in the ID
        /// mapping table (<c>TRUE</c>) or not (<c>FALSE</c>).</para><para>Default is <c>FALSE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IdMappingConfig_AllowUseAsDimensionColumn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the ID namespace association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IdNamespaceAssociationIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the ID namespace association that you want to update.</para>
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
        public System.String IdNamespaceAssociationIdentifier { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the membership that contains the ID namespace association
        /// that you want to update.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A new name for the ID namespace association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdNamespaceAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdNamespaceAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdNamespaceAssociationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CRSIdNamespaceAssociation (UpdateIdNamespaceAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationResponse, UpdateCRSIdNamespaceAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.IdMappingConfig_AllowUseAsDimensionColumn = this.IdMappingConfig_AllowUseAsDimensionColumn;
            context.IdNamespaceAssociationIdentifier = this.IdNamespaceAssociationIdentifier;
            #if MODULAR
            if (this.IdNamespaceAssociationIdentifier == null && ParameterWasBound(nameof(this.IdNamespaceAssociationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IdNamespaceAssociationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            
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
            var request = new Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate IdMappingConfig
            var requestIdMappingConfigIsNull = true;
            request.IdMappingConfig = new Amazon.CleanRooms.Model.IdMappingConfig();
            System.Boolean? requestIdMappingConfig_idMappingConfig_AllowUseAsDimensionColumn = null;
            if (cmdletContext.IdMappingConfig_AllowUseAsDimensionColumn != null)
            {
                requestIdMappingConfig_idMappingConfig_AllowUseAsDimensionColumn = cmdletContext.IdMappingConfig_AllowUseAsDimensionColumn.Value;
            }
            if (requestIdMappingConfig_idMappingConfig_AllowUseAsDimensionColumn != null)
            {
                request.IdMappingConfig.AllowUseAsDimensionColumn = requestIdMappingConfig_idMappingConfig_AllowUseAsDimensionColumn.Value;
                requestIdMappingConfigIsNull = false;
            }
             // determine if request.IdMappingConfig should be set to null
            if (requestIdMappingConfigIsNull)
            {
                request.IdMappingConfig = null;
            }
            if (cmdletContext.IdNamespaceAssociationIdentifier != null)
            {
                request.IdNamespaceAssociationIdentifier = cmdletContext.IdNamespaceAssociationIdentifier;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "UpdateIdNamespaceAssociation");
            try
            {
                return client.UpdateIdNamespaceAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Boolean? IdMappingConfig_AllowUseAsDimensionColumn { get; set; }
            public System.String IdNamespaceAssociationIdentifier { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.CleanRooms.Model.UpdateIdNamespaceAssociationResponse, UpdateCRSIdNamespaceAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdNamespaceAssociation;
        }
        
    }
}
