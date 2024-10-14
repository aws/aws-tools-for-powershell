/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// <note><para>
    /// After you submit a <c>UpdateTrafficPolicyInstance</c> request, there's a brief delay
    /// while Route 53 creates the resource record sets that are specified in the traffic
    /// policy definition. Use <c>GetTrafficPolicyInstance</c> with the <c>id</c> of updated
    /// traffic policy instance confirm that the <c>UpdateTrafficPolicyInstance</c> request
    /// completed successfully. For more information, see the <c>State</c> response element.
    /// </para></note><para>
    /// Updates the resource record sets in a specified hosted zone that were created based
    /// on the settings in a specified traffic policy version.
    /// </para><para>
    /// When you update a traffic policy instance, Amazon Route 53 continues to respond to
    /// DNS queries for the root resource record set name (such as example.com) while it replaces
    /// one group of resource record sets with another. Route 53 performs the following operations:
    /// </para><ol><li><para>
    /// Route 53 creates a new group of resource record sets based on the specified traffic
    /// policy. This is true regardless of how significant the differences are between the
    /// existing resource record sets and the new resource record sets. 
    /// </para></li><li><para>
    /// When all of the new resource record sets have been created, Route 53 starts to respond
    /// to DNS queries for the root resource record set name (such as example.com) by using
    /// the new resource record sets.
    /// </para></li><li><para>
    /// Route 53 deletes the old group of resource record sets that are associated with the
    /// root resource record set name.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Update", "R53TrafficPolicyInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.TrafficPolicyInstance")]
    [AWSCmdlet("Calls the Amazon Route 53 UpdateTrafficPolicyInstance API operation.", Operation = new[] {"UpdateTrafficPolicyInstance"}, SelectReturnType = typeof(Amazon.Route53.Model.UpdateTrafficPolicyInstanceResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.TrafficPolicyInstance or Amazon.Route53.Model.UpdateTrafficPolicyInstanceResponse",
        "This cmdlet returns an Amazon.Route53.Model.TrafficPolicyInstance object.",
        "The service call response (type Amazon.Route53.Model.UpdateTrafficPolicyInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateR53TrafficPolicyInstanceCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the traffic policy instance that you want to update.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the traffic policy that you want Amazon Route 53 to use to update resource
        /// record sets for the specified traffic policy instance.</para>
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
        public System.String TrafficPolicyId { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyVersion
        /// <summary>
        /// <para>
        /// <para>The version of the traffic policy that you want Amazon Route 53 to use to update resource
        /// record sets for the specified traffic policy instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TrafficPolicyVersion { get; set; }
        #endregion
        
        #region Parameter TTL
        /// <summary>
        /// <para>
        /// <para>The TTL that you want Amazon Route 53 to assign to all of the updated resource record
        /// sets.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? TTL { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficPolicyInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.UpdateTrafficPolicyInstanceResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.UpdateTrafficPolicyInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficPolicyInstance";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53TrafficPolicyInstance (UpdateTrafficPolicyInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.UpdateTrafficPolicyInstanceResponse, UpdateR53TrafficPolicyInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TTL = this.TTL;
            #if MODULAR
            if (this.TTL == null && ParameterWasBound(nameof(this.TTL)))
            {
                WriteWarning("You are passing $null as a value for parameter TTL which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrafficPolicyId = this.TrafficPolicyId;
            #if MODULAR
            if (this.TrafficPolicyId == null && ParameterWasBound(nameof(this.TrafficPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrafficPolicyVersion = this.TrafficPolicyVersion;
            #if MODULAR
            if (this.TrafficPolicyVersion == null && ParameterWasBound(nameof(this.TrafficPolicyVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficPolicyVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.UpdateTrafficPolicyInstanceRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.TTL != null)
            {
                request.TTL = cmdletContext.TTL.Value;
            }
            if (cmdletContext.TrafficPolicyId != null)
            {
                request.TrafficPolicyId = cmdletContext.TrafficPolicyId;
            }
            if (cmdletContext.TrafficPolicyVersion != null)
            {
                request.TrafficPolicyVersion = cmdletContext.TrafficPolicyVersion.Value;
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
        
        private Amazon.Route53.Model.UpdateTrafficPolicyInstanceResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.UpdateTrafficPolicyInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "UpdateTrafficPolicyInstance");
            try
            {
                #if DESKTOP
                return client.UpdateTrafficPolicyInstance(request);
                #elif CORECLR
                return client.UpdateTrafficPolicyInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.Int64? TTL { get; set; }
            public System.String TrafficPolicyId { get; set; }
            public System.Int32? TrafficPolicyVersion { get; set; }
            public System.Func<Amazon.Route53.Model.UpdateTrafficPolicyInstanceResponse, UpdateR53TrafficPolicyInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficPolicyInstance;
        }
        
    }
}
