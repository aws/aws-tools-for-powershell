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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Put template post migration custom action.
    /// </summary>
    [Cmdlet("Write", "MGNTemplateAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.PutTemplateActionResponse")]
    [AWSCmdlet("Calls the Application Migration Service PutTemplateAction API operation.", Operation = new[] {"PutTemplateAction"}, SelectReturnType = typeof(Amazon.Mgn.Model.PutTemplateActionResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.PutTemplateActionResponse",
        "This cmdlet returns an Amazon.Mgn.Model.PutTemplateActionResponse object containing multiple properties."
    )]
    public partial class WriteMGNTemplateActionCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionID
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action ID.</para>
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
        public System.String ActionID { get; set; }
        #endregion
        
        #region Parameter ActionName
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action name.</para>
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
        public System.String ActionName { get; set; }
        #endregion
        
        #region Parameter Active
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action active status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Active { get; set; }
        #endregion
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action category.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.ActionCategory")]
        public Amazon.Mgn.ActionCategory Category { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DocumentIdentifier
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action document identifier.</para>
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
        public System.String DocumentIdentifier { get; set; }
        #endregion
        
        #region Parameter DocumentVersion
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action document version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentVersion { get; set; }
        #endregion
        
        #region Parameter ExternalParameter
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action external parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExternalParameters")]
        public System.Collections.Hashtable ExternalParameter { get; set; }
        #endregion
        
        #region Parameter LaunchConfigurationTemplateID
        /// <summary>
        /// <para>
        /// <para>Launch configuration template ID.</para>
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
        public System.String LaunchConfigurationTemplateID { get; set; }
        #endregion
        
        #region Parameter MustSucceedForCutover
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action must succeed for cutover.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MustSucceedForCutover { get; set; }
        #endregion
        
        #region Parameter OperatingSystem
        /// <summary>
        /// <para>
        /// <para>Operating system eligible for this template post migration custom action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingSystem { get; set; }
        #endregion
        
        #region Parameter Order
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action order.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Order { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Template post migration custom action timeout in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutSeconds")]
        public System.Int32? TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.PutTemplateActionResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.PutTemplateActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-MGNTemplateAction (PutTemplateAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.PutTemplateActionResponse, WriteMGNTemplateActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionID = this.ActionID;
            #if MODULAR
            if (this.ActionID == null && ParameterWasBound(nameof(this.ActionID)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionName = this.ActionName;
            #if MODULAR
            if (this.ActionName == null && ParameterWasBound(nameof(this.ActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Active = this.Active;
            context.Category = this.Category;
            context.Description = this.Description;
            context.DocumentIdentifier = this.DocumentIdentifier;
            #if MODULAR
            if (this.DocumentIdentifier == null && ParameterWasBound(nameof(this.DocumentIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DocumentVersion = this.DocumentVersion;
            if (this.ExternalParameter != null)
            {
                context.ExternalParameter = new Dictionary<System.String, Amazon.Mgn.Model.SsmExternalParameter>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExternalParameter.Keys)
                {
                    context.ExternalParameter.Add((String)hashKey, (Amazon.Mgn.Model.SsmExternalParameter)(this.ExternalParameter[hashKey]));
                }
            }
            context.LaunchConfigurationTemplateID = this.LaunchConfigurationTemplateID;
            #if MODULAR
            if (this.LaunchConfigurationTemplateID == null && ParameterWasBound(nameof(this.LaunchConfigurationTemplateID)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchConfigurationTemplateID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MustSucceedForCutover = this.MustSucceedForCutover;
            context.OperatingSystem = this.OperatingSystem;
            context.Order = this.Order;
            #if MODULAR
            if (this.Order == null && ParameterWasBound(nameof(this.Order)))
            {
                WriteWarning("You are passing $null as a value for parameter Order which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, List<Amazon.Mgn.Model.SsmParameterStoreParameter>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.Mgn.Model.SsmParameterStoreParameter>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.Mgn.Model.SsmParameterStoreParameter)s);
                    }
                    context.Parameter.Add((String)hashKey, valueSet);
                }
            }
            context.TimeoutSecond = this.TimeoutSecond;
            
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
            var request = new Amazon.Mgn.Model.PutTemplateActionRequest();
            
            if (cmdletContext.ActionID != null)
            {
                request.ActionID = cmdletContext.ActionID;
            }
            if (cmdletContext.ActionName != null)
            {
                request.ActionName = cmdletContext.ActionName;
            }
            if (cmdletContext.Active != null)
            {
                request.Active = cmdletContext.Active.Value;
            }
            if (cmdletContext.Category != null)
            {
                request.Category = cmdletContext.Category;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DocumentIdentifier != null)
            {
                request.DocumentIdentifier = cmdletContext.DocumentIdentifier;
            }
            if (cmdletContext.DocumentVersion != null)
            {
                request.DocumentVersion = cmdletContext.DocumentVersion;
            }
            if (cmdletContext.ExternalParameter != null)
            {
                request.ExternalParameters = cmdletContext.ExternalParameter;
            }
            if (cmdletContext.LaunchConfigurationTemplateID != null)
            {
                request.LaunchConfigurationTemplateID = cmdletContext.LaunchConfigurationTemplateID;
            }
            if (cmdletContext.MustSucceedForCutover != null)
            {
                request.MustSucceedForCutover = cmdletContext.MustSucceedForCutover.Value;
            }
            if (cmdletContext.OperatingSystem != null)
            {
                request.OperatingSystem = cmdletContext.OperatingSystem;
            }
            if (cmdletContext.Order != null)
            {
                request.Order = cmdletContext.Order.Value;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.TimeoutSecond != null)
            {
                request.TimeoutSeconds = cmdletContext.TimeoutSecond.Value;
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
        
        private Amazon.Mgn.Model.PutTemplateActionResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.PutTemplateActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "PutTemplateAction");
            try
            {
                #if DESKTOP
                return client.PutTemplateAction(request);
                #elif CORECLR
                return client.PutTemplateActionAsync(request).GetAwaiter().GetResult();
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
            public System.String ActionID { get; set; }
            public System.String ActionName { get; set; }
            public System.Boolean? Active { get; set; }
            public Amazon.Mgn.ActionCategory Category { get; set; }
            public System.String Description { get; set; }
            public System.String DocumentIdentifier { get; set; }
            public System.String DocumentVersion { get; set; }
            public Dictionary<System.String, Amazon.Mgn.Model.SsmExternalParameter> ExternalParameter { get; set; }
            public System.String LaunchConfigurationTemplateID { get; set; }
            public System.Boolean? MustSucceedForCutover { get; set; }
            public System.String OperatingSystem { get; set; }
            public System.Int32? Order { get; set; }
            public Dictionary<System.String, List<Amazon.Mgn.Model.SsmParameterStoreParameter>> Parameter { get; set; }
            public System.Int32? TimeoutSecond { get; set; }
            public System.Func<Amazon.Mgn.Model.PutTemplateActionResponse, WriteMGNTemplateActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
