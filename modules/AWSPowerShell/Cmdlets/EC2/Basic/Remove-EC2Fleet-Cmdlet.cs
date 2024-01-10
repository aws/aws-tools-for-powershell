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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Deletes the specified EC2 Fleets.
    /// 
    ///  
    /// <para>
    /// After you delete an EC2 Fleet, it launches no new instances.
    /// </para><para>
    /// You must also specify whether a deleted EC2 Fleet should terminate its instances.
    /// If you choose to terminate the instances, the EC2 Fleet enters the <c>deleted_terminating</c>
    /// state. Otherwise, the EC2 Fleet enters the <c>deleted_running</c> state, and the instances
    /// continue to run until they are interrupted or you terminate them manually.
    /// </para><para>
    /// For <c>instant</c> fleets, EC2 Fleet must terminate the instances when the fleet is
    /// deleted. A deleted <c>instant</c> fleet with running instances is not supported.
    /// </para><para><b>Restrictions</b></para><ul><li><para>
    /// You can delete up to 25 <c>instant</c> fleets in a single request. If you exceed this
    /// number, no <c>instant</c> fleets are deleted and an error is returned. There is no
    /// restriction on the number of fleets of type <c>maintain</c> or <c>request</c> that
    /// can be deleted in a single request.
    /// </para></li><li><para>
    /// Up to 1000 instances can be terminated in a single request to delete <c>instant</c>
    /// fleets.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/manage-ec2-fleet.html#delete-fleet">Delete
    /// an EC2 Fleet</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "EC2Fleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.DeleteFleetsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DeleteFleets API operation.", Operation = new[] {"DeleteFleets"}, SelectReturnType = typeof(Amazon.EC2.Model.DeleteFleetsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.DeleteFleetsResponse",
        "This cmdlet returns an Amazon.EC2.Model.DeleteFleetsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveEC2FleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the EC2 Fleets.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FleetIds")]
        public System.String[] FleetId { get; set; }
        #endregion
        
        #region Parameter TerminateInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to terminate the associated instances when the EC2 Fleet is deleted.
        /// The default is to terminate the instances.</para><para>To let the instances continue to run after the EC2 Fleet is deleted, specify <c>no-terminate-instances</c>.
        /// Supported only for fleets of type <c>maintain</c> and <c>request</c>.</para><para>For <c>instant</c> fleets, you cannot specify <c>NoTerminateInstances</c>. A deleted
        /// <c>instant</c> fleet with running instances is not supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TerminateInstances")]
        public System.Boolean? TerminateInstance { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DeleteFleetsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DeleteFleetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FleetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2Fleet (DeleteFleets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DeleteFleetsResponse, RemoveEC2FleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FleetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FleetId != null)
            {
                context.FleetId = new List<System.String>(this.FleetId);
            }
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TerminateInstance = this.TerminateInstance;
            #if MODULAR
            if (this.TerminateInstance == null && ParameterWasBound(nameof(this.TerminateInstance)))
            {
                WriteWarning("You are passing $null as a value for parameter TerminateInstance which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DeleteFleetsRequest();
            
            if (cmdletContext.FleetId != null)
            {
                request.FleetIds = cmdletContext.FleetId;
            }
            if (cmdletContext.TerminateInstance != null)
            {
                request.TerminateInstances = cmdletContext.TerminateInstance.Value;
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
        
        private Amazon.EC2.Model.DeleteFleetsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteFleetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DeleteFleets");
            try
            {
                #if DESKTOP
                return client.DeleteFleets(request);
                #elif CORECLR
                return client.DeleteFleetsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> FleetId { get; set; }
            public System.Boolean? TerminateInstance { get; set; }
            public System.Func<Amazon.EC2.Model.DeleteFleetsResponse, RemoveEC2FleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
