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
using Amazon.DataZone;
using Amazon.DataZone.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Updates the specified project in Amazon DataZone.
    /// </summary>
    [Cmdlet("Update", "DZProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon DataZone UpdateProject API operation.", Operation = new[] {"UpdateProject"}, SelectReturnType = typeof(Amazon.DataZone.Model.UpdateProjectResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataZone.Model.UpdateProjectResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataZone.Model.UpdateProjectResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateDZProjectCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to be updated as part of the <c>UpdateProject</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon DataZone domain where a project is being updated.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter EnvironmentDeploymentDetails_EnvironmentFailureReason
        /// <summary>
        /// <para>
        /// <para>Environment failure reasons.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentDeploymentDetails_EnvironmentFailureReasons")]
        public System.Collections.Hashtable EnvironmentDeploymentDetails_EnvironmentFailureReason { get; set; }
        #endregion
        
        #region Parameter GlossaryTerm
        /// <summary>
        /// <para>
        /// <para>The glossary terms to be updated as part of the <c>UpdateProject</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GlossaryTerms")]
        public System.String[] GlossaryTerm { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the project that is to be updated.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name to be updated as part of the <c>UpdateProject</c> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EnvironmentDeploymentDetails_OverallDeploymentStatus
        /// <summary>
        /// <para>
        /// <para>The overall deployment status of the environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.OverallDeploymentStatus")]
        public Amazon.DataZone.OverallDeploymentStatus EnvironmentDeploymentDetails_OverallDeploymentStatus { get; set; }
        #endregion
        
        #region Parameter ProjectProfileVersion
        /// <summary>
        /// <para>
        /// <para>The project profile version to which the project should be updated. You can only specify
        /// the following string for this parameter: <c>latest</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectProfileVersion { get; set; }
        #endregion
        
        #region Parameter UserParameter
        /// <summary>
        /// <para>
        /// <para>The user parameters of the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserParameters")]
        public Amazon.DataZone.Model.EnvironmentConfigurationUserParameter[] UserParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.UpdateProjectResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.UpdateProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DZProject (UpdateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.UpdateProjectResponse, UpdateDZProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EnvironmentDeploymentDetails_EnvironmentFailureReason != null)
            {
                context.EnvironmentDeploymentDetails_EnvironmentFailureReason = new Dictionary<System.String, List<Amazon.DataZone.Model.EnvironmentError>>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentDeploymentDetails_EnvironmentFailureReason.Keys)
                {
                    object hashValue = this.EnvironmentDeploymentDetails_EnvironmentFailureReason[hashKey];
                    if (hashValue == null)
                    {
                        context.EnvironmentDeploymentDetails_EnvironmentFailureReason.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.DataZone.Model.EnvironmentError>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.DataZone.Model.EnvironmentError)s);
                    }
                    context.EnvironmentDeploymentDetails_EnvironmentFailureReason.Add((String)hashKey, valueSet);
                }
            }
            context.EnvironmentDeploymentDetails_OverallDeploymentStatus = this.EnvironmentDeploymentDetails_OverallDeploymentStatus;
            if (this.GlossaryTerm != null)
            {
                context.GlossaryTerm = new List<System.String>(this.GlossaryTerm);
            }
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.ProjectProfileVersion = this.ProjectProfileVersion;
            if (this.UserParameter != null)
            {
                context.UserParameter = new List<Amazon.DataZone.Model.EnvironmentConfigurationUserParameter>(this.UserParameter);
            }
            
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
            var request = new Amazon.DataZone.Model.UpdateProjectRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            
             // populate EnvironmentDeploymentDetails
            var requestEnvironmentDeploymentDetailsIsNull = true;
            request.EnvironmentDeploymentDetails = new Amazon.DataZone.Model.EnvironmentDeploymentDetails();
            Dictionary<System.String, List<Amazon.DataZone.Model.EnvironmentError>> requestEnvironmentDeploymentDetails_environmentDeploymentDetails_EnvironmentFailureReason = null;
            if (cmdletContext.EnvironmentDeploymentDetails_EnvironmentFailureReason != null)
            {
                requestEnvironmentDeploymentDetails_environmentDeploymentDetails_EnvironmentFailureReason = cmdletContext.EnvironmentDeploymentDetails_EnvironmentFailureReason;
            }
            if (requestEnvironmentDeploymentDetails_environmentDeploymentDetails_EnvironmentFailureReason != null)
            {
                request.EnvironmentDeploymentDetails.EnvironmentFailureReasons = requestEnvironmentDeploymentDetails_environmentDeploymentDetails_EnvironmentFailureReason;
                requestEnvironmentDeploymentDetailsIsNull = false;
            }
            Amazon.DataZone.OverallDeploymentStatus requestEnvironmentDeploymentDetails_environmentDeploymentDetails_OverallDeploymentStatus = null;
            if (cmdletContext.EnvironmentDeploymentDetails_OverallDeploymentStatus != null)
            {
                requestEnvironmentDeploymentDetails_environmentDeploymentDetails_OverallDeploymentStatus = cmdletContext.EnvironmentDeploymentDetails_OverallDeploymentStatus;
            }
            if (requestEnvironmentDeploymentDetails_environmentDeploymentDetails_OverallDeploymentStatus != null)
            {
                request.EnvironmentDeploymentDetails.OverallDeploymentStatus = requestEnvironmentDeploymentDetails_environmentDeploymentDetails_OverallDeploymentStatus;
                requestEnvironmentDeploymentDetailsIsNull = false;
            }
             // determine if request.EnvironmentDeploymentDetails should be set to null
            if (requestEnvironmentDeploymentDetailsIsNull)
            {
                request.EnvironmentDeploymentDetails = null;
            }
            if (cmdletContext.GlossaryTerm != null)
            {
                request.GlossaryTerms = cmdletContext.GlossaryTerm;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProjectProfileVersion != null)
            {
                request.ProjectProfileVersion = cmdletContext.ProjectProfileVersion;
            }
            if (cmdletContext.UserParameter != null)
            {
                request.UserParameters = cmdletContext.UserParameter;
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
        
        private Amazon.DataZone.Model.UpdateProjectResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.UpdateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "UpdateProject");
            try
            {
                return client.UpdateProjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainIdentifier { get; set; }
            public Dictionary<System.String, List<Amazon.DataZone.Model.EnvironmentError>> EnvironmentDeploymentDetails_EnvironmentFailureReason { get; set; }
            public Amazon.DataZone.OverallDeploymentStatus EnvironmentDeploymentDetails_OverallDeploymentStatus { get; set; }
            public List<System.String> GlossaryTerm { get; set; }
            public System.String Identifier { get; set; }
            public System.String Name { get; set; }
            public System.String ProjectProfileVersion { get; set; }
            public List<Amazon.DataZone.Model.EnvironmentConfigurationUserParameter> UserParameter { get; set; }
            public System.Func<Amazon.DataZone.Model.UpdateProjectResponse, UpdateDZProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
