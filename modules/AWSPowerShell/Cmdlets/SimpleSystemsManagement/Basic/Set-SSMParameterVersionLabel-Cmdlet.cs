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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// A parameter label is a user-defined alias to help you manage different versions of
    /// a parameter. When you modify a parameter, Amazon Web Services Systems Manager automatically
    /// saves a new version and increments the version number by one. A label can help you
    /// remember the purpose of a parameter when there are multiple versions. 
    /// 
    ///  
    /// <para>
    /// Parameter labels have the following requirements and restrictions.
    /// </para><ul><li><para>
    /// A version of a parameter can have a maximum of 10 labels.
    /// </para></li><li><para>
    /// You can't attach the same label to different versions of the same parameter. For example,
    /// if version 1 has the label Production, then you can't attach Production to version
    /// 2.
    /// </para></li><li><para>
    /// You can move a label from one version of a parameter to another.
    /// </para></li><li><para>
    /// You can't create a label when you create a new parameter. You must attach a label
    /// to a specific version of a parameter.
    /// </para></li><li><para>
    /// If you no longer want to use a parameter label, then you can either delete it or move
    /// it to a different version of a parameter.
    /// </para></li><li><para>
    /// A label can have a maximum of 100 characters.
    /// </para></li><li><para>
    /// Labels can contain letters (case sensitive), numbers, periods (.), hyphens (-), or
    /// underscores (_).
    /// </para></li><li><para>
    /// Labels can't begin with a number, "<c>aws</c>" or "<c>ssm</c>" (not case sensitive).
    /// If a label fails to meet these requirements, then the label isn't associated with
    /// a parameter and the system displays it in the list of InvalidLabels.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Set", "SSMParameterVersionLabel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager LabelParameterVersion API operation.", Operation = new[] {"LabelParameterVersion"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.LabelParameterVersionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleSystemsManagement.Model.LabelParameterVersionResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.LabelParameterVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetSSMParameterVersionLabelCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>One or more labels to attach to the specified parameter version.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Labels")]
        public System.String[] Label { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The parameter name on which you want to attach one or more labels.</para><note><para>You can't enter the Amazon Resource Name (ARN) for a parameter, only the parameter
        /// name itself.</para></note>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParameterVersion
        /// <summary>
        /// <para>
        /// <para>The specific version of the parameter on which you want to attach one or more labels.
        /// If no version is specified, the system attaches the label to the latest version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ParameterVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvalidLabels'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.LabelParameterVersionResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.LabelParameterVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvalidLabels";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SSMParameterVersionLabel (LabelParameterVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.LabelParameterVersionResponse, SetSSMParameterVersionLabelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Label != null)
            {
                context.Label = new List<System.String>(this.Label);
            }
            #if MODULAR
            if (this.Label == null && ParameterWasBound(nameof(this.Label)))
            {
                WriteWarning("You are passing $null as a value for parameter Label which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParameterVersion = this.ParameterVersion;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.LabelParameterVersionRequest();
            
            if (cmdletContext.Label != null)
            {
                request.Labels = cmdletContext.Label;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ParameterVersion != null)
            {
                request.ParameterVersion = cmdletContext.ParameterVersion.Value;
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
        
        private Amazon.SimpleSystemsManagement.Model.LabelParameterVersionResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.LabelParameterVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "LabelParameterVersion");
            try
            {
                return client.LabelParameterVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Label { get; set; }
            public System.String Name { get; set; }
            public System.Int64? ParameterVersion { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.LabelParameterVersionResponse, SetSSMParameterVersionLabelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvalidLabels;
        }
        
    }
}
