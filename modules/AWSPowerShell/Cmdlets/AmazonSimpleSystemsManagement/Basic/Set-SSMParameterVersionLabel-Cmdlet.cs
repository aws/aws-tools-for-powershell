/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// A parameter label is a user-defined alias to help you manage different versions of
    /// a parameter. When you modify a parameter, Systems Manager automatically saves a new
    /// version and increments the version number by one. A label can help you remember the
    /// purpose of a parameter when there are multiple versions. 
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
    /// You can't delete a parameter label. If you no longer want to use a parameter label,
    /// then you must move it to a different version of a parameter.
    /// </para></li><li><para>
    /// A label can have a maximum of 100 characters.
    /// </para></li><li><para>
    /// Labels can contain letters (case sensitive), numbers, periods (.), hyphens (-), or
    /// underscores (_).
    /// </para></li><li><para>
    /// Labels can't begin with a number, "aws," or "ssm" (not case sensitive). If a label
    /// fails to meet these requirements, then the label is not associated with a parameter
    /// and the system displays it in the list of InvalidLabels.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Set", "SSMParameterVersionLabel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager LabelParameterVersion API operation.", Operation = new[] {"LabelParameterVersion"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.LabelParameterVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetSSMParameterVersionLabelCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>One or more labels to attach to the specified parameter version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Labels")]
        public System.String[] Label { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The parameter name on which you want to attach one or more labels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParameterVersion
        /// <summary>
        /// <para>
        /// <para>The specific version of the parameter on which you want to attach one or more labels.
        /// If no version is specified, the system attaches the label to the latest version.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ParameterVersion { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SSMParameterVersionLabel (LabelParameterVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Label != null)
            {
                context.Labels = new List<System.String>(this.Label);
            }
            context.Name = this.Name;
            if (ParameterWasBound("ParameterVersion"))
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
            
            if (cmdletContext.Labels != null)
            {
                request.Labels = cmdletContext.Labels;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InvalidLabels;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                #if DESKTOP
                return client.LabelParameterVersion(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.LabelParameterVersionAsync(request);
                return task.Result;
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
            public List<System.String> Labels { get; set; }
            public System.String Name { get; set; }
            public System.Int64? ParameterVersion { get; set; }
        }
        
    }
}
