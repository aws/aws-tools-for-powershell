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
using Amazon.Route53Profiles;
using Amazon.Route53Profiles.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53P
{
    /// <summary>
    /// Updates the name or priority of the specified Route 53 Profile association with a
    /// VPC. Route 53 VPC Resolver evaluates the Profile associations for a VPC in priority
    /// order, starting with the lowest value. Only the account that created the association
    /// can update it. 
    /// 
    ///  
    /// <para>
    ///  When you change the priority, the association status is <c>UPDATING</c> until the
    /// change propagates, and then <c>COMPLETE</c>. While the status is <c>UPDATING</c>,
    /// Route 53 VPC Resolver might still use the previous priority for some queries. When
    /// the status is <c>COMPLETE</c>, the new priority applies to all queries from the VPC.
    /// 
    /// </para><para>
    ///  The request fails with a <c>ValidationException</c> if another Profile association
    /// for the VPC already uses the priority that you specify, or if the priority is outside
    /// the range 100–9900. 
    /// </para><para>
    ///  You can update an association whose status is <c>CREATING</c>, <c>UPDATING</c>, or
    /// <c>COMPLETE</c>. The request fails with a <c>ConflictException</c> if the association
    /// status is <c>DELETING</c>, <c>DELETED</c>, or <c>FAILED</c>, or if the account that
    /// owns the association is inactive. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53PProfileAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Profiles.Model.ProfileAssociation")]
    [AWSCmdlet("Calls the Amazon Route 53 Profiles UpdateProfileAssociation API operation.", Operation = new[] {"UpdateProfileAssociation"}, SelectReturnType = typeof(Amazon.Route53Profiles.Model.UpdateProfileAssociationResponse))]
    [AWSCmdletOutput("Amazon.Route53Profiles.Model.ProfileAssociation or Amazon.Route53Profiles.Model.UpdateProfileAssociationResponse",
        "This cmdlet returns an Amazon.Route53Profiles.Model.ProfileAssociation object.",
        "The service call response (type Amazon.Route53Profiles.Model.UpdateProfileAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateR53PProfileAssociationCmdlet : AmazonRoute53ProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the Profile association. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para> The new priority of the Profile association. Route 53 VPC Resolver evaluates the
        /// Profile associations for a VPC in priority order, starting with the lowest value.
        /// </para><para>The priority must be unique among the Profile associations for the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter ProfileAssociationId
        /// <summary>
        /// <para>
        /// <para> The ID of the Profile association to update. </para>
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
        public System.String ProfileAssociationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProfileAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Profiles.Model.UpdateProfileAssociationResponse).
        /// Specifying the name of a property of type Amazon.Route53Profiles.Model.UpdateProfileAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProfileAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileAssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53PProfileAssociation (UpdateProfileAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Profiles.Model.UpdateProfileAssociationResponse, UpdateR53PProfileAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            context.Priority = this.Priority;
            context.ProfileAssociationId = this.ProfileAssociationId;
            #if MODULAR
            if (this.ProfileAssociationId == null && ParameterWasBound(nameof(this.ProfileAssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileAssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53Profiles.Model.UpdateProfileAssociationRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.ProfileAssociationId != null)
            {
                request.ProfileAssociationId = cmdletContext.ProfileAssociationId;
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
        
        private Amazon.Route53Profiles.Model.UpdateProfileAssociationResponse CallAWSServiceOperation(IAmazonRoute53Profiles client, Amazon.Route53Profiles.Model.UpdateProfileAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Profiles", "UpdateProfileAssociation");
            try
            {
                return client.UpdateProfileAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String ProfileAssociationId { get; set; }
            public System.Func<Amazon.Route53Profiles.Model.UpdateProfileAssociationResponse, UpdateR53PProfileAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProfileAssociation;
        }
        
    }
}
