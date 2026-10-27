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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Starts a specific Amazon Lightsail instance from a stopped state. To restart an instance,
    /// use the <c>reboot instance</c> operation.
    /// 
    ///  <note><para>
    /// When you start a stopped instance, Lightsail assigns a new public IP address to the
    /// instance. To use the same IP address after stopping and starting an instance, create
    /// a static IP address and attach it to the instance. For more information, see the <a href="https://docs.aws.amazon.com/lightsail/latest/userguide/lightsail-create-static-ip">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para></note><para>
    /// The <c>start instance</c> operation supports tag-based access control via resource
    /// tags applied to the resource identified by <c>instance name</c>. For more information,
    /// see the <a href="https://docs.aws.amazon.com/lightsail/latest/userguide/amazon-lightsail-controlling-access-using-tags">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "LSInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail StartInstance API operation.", Operation = new[] {"StartInstance"}, SelectReturnType = typeof(Amazon.Lightsail.Model.StartInstanceResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.StartInstanceResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.StartInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartLSInstanceCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttributeUpdates_BundleId
        /// <summary>
        /// <para>
        /// <para>The ID of the bundle to update the instance to.</para><para>Specify one of the following values for the bundle ID:</para><ul><li><para><b><c>auto</c></b> – Updates an instance that runs on a previous-generation bundle
        /// to the newer-generation equivalent of that bundle. For example, specify <c>auto</c>
        /// to update an instance that runs on <c>small_2_0</c> to <c>small_3_0</c>.</para></li><li><para><b>Newer-generation bundle ID</b> – Updates an instance that runs on a previous-generation
        /// bundle to the specified bundle. For example, specify <c>small_3_0</c> to update an
        /// instance that runs on <c>small_2_0</c> to <c>small_3_0</c>.</para></li><li><para><b>Original bundle ID</b> – Updates an instance to the previous-generation bundle
        /// that it ran on before an earlier update. For example, specify <c>small_2_0</c> to
        /// return an instance that runs on <c>small_3_0</c> to <c>small_2_0</c>.</para></li></ul><note><para>The instance must be in the <c>stopped</c> state to update its bundle.</para><para>There is no additional cost to update an instance to a newer-generation bundle.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttributeUpdates_BundleId { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the instance (a virtual private server) to start.</para>
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
        public System.String InstanceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.StartInstanceResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.StartInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LSInstance (StartInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.StartInstanceResponse, StartLSInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttributeUpdates_BundleId = this.AttributeUpdates_BundleId;
            context.InstanceName = this.InstanceName;
            #if MODULAR
            if (this.InstanceName == null && ParameterWasBound(nameof(this.InstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.StartInstanceRequest();
            
            
             // populate AttributeUpdates
            var requestAttributeUpdatesIsNull = true;
            request.AttributeUpdates = new Amazon.Lightsail.Model.InstanceAttributeUpdates();
            System.String requestAttributeUpdates_attributeUpdates_BundleId = null;
            if (cmdletContext.AttributeUpdates_BundleId != null)
            {
                requestAttributeUpdates_attributeUpdates_BundleId = cmdletContext.AttributeUpdates_BundleId;
            }
            if (requestAttributeUpdates_attributeUpdates_BundleId != null)
            {
                request.AttributeUpdates.BundleId = requestAttributeUpdates_attributeUpdates_BundleId;
                requestAttributeUpdatesIsNull = false;
            }
             // determine if request.AttributeUpdates should be set to null
            if (requestAttributeUpdatesIsNull)
            {
                request.AttributeUpdates = null;
            }
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceName = cmdletContext.InstanceName;
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
        
        private Amazon.Lightsail.Model.StartInstanceResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.StartInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "StartInstance");
            try
            {
                return client.StartInstanceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttributeUpdates_BundleId { get; set; }
            public System.String InstanceName { get; set; }
            public System.Func<Amazon.Lightsail.Model.StartInstanceResponse, StartLSInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
