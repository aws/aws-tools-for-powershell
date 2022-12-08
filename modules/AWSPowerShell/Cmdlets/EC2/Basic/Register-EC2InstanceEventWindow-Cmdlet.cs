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
    /// Associates one or more targets with an event window. Only one type of target (instance
    /// IDs, Dedicated Host IDs, or tags) can be specified with an event window.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/event-windows.html">Define
    /// event windows for scheduled events</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2InstanceEventWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.InstanceEventWindow")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AssociateInstanceEventWindow API operation.", Operation = new[] {"AssociateInstanceEventWindow"}, SelectReturnType = typeof(Amazon.EC2.Model.AssociateInstanceEventWindowResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceEventWindow or Amazon.EC2.Model.AssociateInstanceEventWindowResponse",
        "This cmdlet returns an Amazon.EC2.Model.InstanceEventWindow object.",
        "The service call response (type Amazon.EC2.Model.AssociateInstanceEventWindowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterEC2InstanceEventWindowCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AssociationTarget_DedicatedHostId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Dedicated Hosts to associate with the event window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociationTarget_DedicatedHostIds")]
        public System.String[] AssociationTarget_DedicatedHostId { get; set; }
        #endregion
        
        #region Parameter InstanceEventWindowId
        /// <summary>
        /// <para>
        /// <para>The ID of the event window.</para>
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
        public System.String InstanceEventWindowId { get; set; }
        #endregion
        
        #region Parameter AssociationTarget_InstanceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the instances to associate with the event window. If the instance is on
        /// a Dedicated Host, you can't specify the Instance ID parameter; you must use the Dedicated
        /// Host ID parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociationTarget_InstanceIds")]
        public object[] AssociationTarget_InstanceId { get; set; }
        #endregion
        
        #region Parameter AssociationTarget_InstanceTag
        /// <summary>
        /// <para>
        /// <para>The instance tags to associate with the event window. Any instances associated with
        /// the tags will be associated with the event window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociationTarget_InstanceTags")]
        public Amazon.EC2.Model.Tag[] AssociationTarget_InstanceTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceEventWindow'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AssociateInstanceEventWindowResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AssociateInstanceEventWindowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceEventWindow";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceEventWindowId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceEventWindowId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceEventWindowId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceEventWindowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2InstanceEventWindow (AssociateInstanceEventWindow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AssociateInstanceEventWindowResponse, RegisterEC2InstanceEventWindowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceEventWindowId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AssociationTarget_DedicatedHostId != null)
            {
                context.AssociationTarget_DedicatedHostId = new List<System.String>(this.AssociationTarget_DedicatedHostId);
            }
            if (this.AssociationTarget_InstanceId != null)
            {
                context.AssociationTarget_InstanceId = AmazonEC2Helper.InstanceParamToIDs(this.AssociationTarget_InstanceId);
            }
            
            if (this.AssociationTarget_InstanceTag != null)
            {
                context.AssociationTarget_InstanceTag = new List<Amazon.EC2.Model.Tag>(this.AssociationTarget_InstanceTag);
            }
            context.InstanceEventWindowId = this.InstanceEventWindowId;
            #if MODULAR
            if (this.InstanceEventWindowId == null && ParameterWasBound(nameof(this.InstanceEventWindowId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceEventWindowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.AssociateInstanceEventWindowRequest();
            
            
             // populate AssociationTarget
            var requestAssociationTargetIsNull = true;
            request.AssociationTarget = new Amazon.EC2.Model.InstanceEventWindowAssociationRequest();
            List<System.String> requestAssociationTarget_associationTarget_DedicatedHostId = null;
            if (cmdletContext.AssociationTarget_DedicatedHostId != null)
            {
                requestAssociationTarget_associationTarget_DedicatedHostId = cmdletContext.AssociationTarget_DedicatedHostId;
            }
            if (requestAssociationTarget_associationTarget_DedicatedHostId != null)
            {
                request.AssociationTarget.DedicatedHostIds = requestAssociationTarget_associationTarget_DedicatedHostId;
                requestAssociationTargetIsNull = false;
            }
            List<System.String> requestAssociationTarget_associationTarget_InstanceId = null;
            if (cmdletContext.AssociationTarget_InstanceId != null)
            {
                requestAssociationTarget_associationTarget_InstanceId = cmdletContext.AssociationTarget_InstanceId;
            }
            if (requestAssociationTarget_associationTarget_InstanceId != null)
            {
                request.AssociationTarget.InstanceIds = requestAssociationTarget_associationTarget_InstanceId;
                requestAssociationTargetIsNull = false;
            }
            List<Amazon.EC2.Model.Tag> requestAssociationTarget_associationTarget_InstanceTag = null;
            if (cmdletContext.AssociationTarget_InstanceTag != null)
            {
                requestAssociationTarget_associationTarget_InstanceTag = cmdletContext.AssociationTarget_InstanceTag;
            }
            if (requestAssociationTarget_associationTarget_InstanceTag != null)
            {
                request.AssociationTarget.InstanceTags = requestAssociationTarget_associationTarget_InstanceTag;
                requestAssociationTargetIsNull = false;
            }
             // determine if request.AssociationTarget should be set to null
            if (requestAssociationTargetIsNull)
            {
                request.AssociationTarget = null;
            }
            if (cmdletContext.InstanceEventWindowId != null)
            {
                request.InstanceEventWindowId = cmdletContext.InstanceEventWindowId;
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
        
        private Amazon.EC2.Model.AssociateInstanceEventWindowResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AssociateInstanceEventWindowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AssociateInstanceEventWindow");
            try
            {
                #if DESKTOP
                return client.AssociateInstanceEventWindow(request);
                #elif CORECLR
                return client.AssociateInstanceEventWindowAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AssociationTarget_DedicatedHostId { get; set; }
            public List<System.String> AssociationTarget_InstanceId { get; set; }
            public List<Amazon.EC2.Model.Tag> AssociationTarget_InstanceTag { get; set; }
            public System.String InstanceEventWindowId { get; set; }
            public System.Func<Amazon.EC2.Model.AssociateInstanceEventWindowResponse, RegisterEC2InstanceEventWindowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceEventWindow;
        }
        
    }
}
