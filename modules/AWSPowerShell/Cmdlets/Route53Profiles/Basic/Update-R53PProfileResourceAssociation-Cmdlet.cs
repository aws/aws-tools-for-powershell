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

namespace Amazon.PowerShell.Cmdlets.R53P
{
    /// <summary>
    /// Updates the specified Route 53 Profile resourse association.
    /// </summary>
    [Cmdlet("Update", "R53PProfileResourceAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Profiles.Model.ProfileResourceAssociation")]
    [AWSCmdlet("Calls the Amazon Route 53 Profiles UpdateProfileResourceAssociation API operation.", Operation = new[] {"UpdateProfileResourceAssociation"}, SelectReturnType = typeof(Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationResponse))]
    [AWSCmdletOutput("Amazon.Route53Profiles.Model.ProfileResourceAssociation or Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationResponse",
        "This cmdlet returns an Amazon.Route53Profiles.Model.ProfileResourceAssociation object.",
        "The service call response (type Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateR53PProfileResourceAssociationCmdlet : AmazonRoute53ProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> Name of the resource association. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProfileResourceAssociationId
        /// <summary>
        /// <para>
        /// <para> ID of the resource association. </para>
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
        public System.String ProfileResourceAssociationId { get; set; }
        #endregion
        
        #region Parameter ResourceProperty
        /// <summary>
        /// <para>
        /// <para> If you are adding a DNS Firewall rule group, include also a priority. The priority
        /// indicates the processing order for the rule groups, starting with the priority assinged
        /// the lowest value. </para><para>The allowed values for priority are between 100 and 9900.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceProperties")]
        public System.String ResourceProperty { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProfileResourceAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationResponse).
        /// Specifying the name of a property of type Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProfileResourceAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileResourceAssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53PProfileResourceAssociation (UpdateProfileResourceAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationResponse, UpdateR53PProfileResourceAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            context.ProfileResourceAssociationId = this.ProfileResourceAssociationId;
            #if MODULAR
            if (this.ProfileResourceAssociationId == null && ParameterWasBound(nameof(this.ProfileResourceAssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileResourceAssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceProperty = this.ResourceProperty;
            
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
            var request = new Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProfileResourceAssociationId != null)
            {
                request.ProfileResourceAssociationId = cmdletContext.ProfileResourceAssociationId;
            }
            if (cmdletContext.ResourceProperty != null)
            {
                request.ResourceProperties = cmdletContext.ResourceProperty;
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
        
        private Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationResponse CallAWSServiceOperation(IAmazonRoute53Profiles client, Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Profiles", "UpdateProfileResourceAssociation");
            try
            {
                return client.UpdateProfileResourceAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ProfileResourceAssociationId { get; set; }
            public System.String ResourceProperty { get; set; }
            public System.Func<Amazon.Route53Profiles.Model.UpdateProfileResourceAssociationResponse, UpdateR53PProfileResourceAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProfileResourceAssociation;
        }
        
    }
}
