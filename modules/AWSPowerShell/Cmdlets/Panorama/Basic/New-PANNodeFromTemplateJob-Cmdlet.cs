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
using Amazon.Panorama;
using Amazon.Panorama.Model;

namespace Amazon.PowerShell.Cmdlets.PAN
{
    /// <summary>
    /// Creates a camera stream node.
    /// </summary>
    [Cmdlet("New", "PANNodeFromTemplateJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Panorama CreateNodeFromTemplateJob API operation.", Operation = new[] {"CreateNodeFromTemplateJob"}, SelectReturnType = typeof(Amazon.Panorama.Model.CreateNodeFromTemplateJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Panorama.Model.CreateNodeFromTemplateJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Panorama.Model.CreateNodeFromTemplateJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPANNodeFromTemplateJobCmdlet : AmazonPanoramaClientCmdlet, IExecutor
    {
        
        #region Parameter JobTag
        /// <summary>
        /// <para>
        /// <para>Tags for the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTags")]
        public Amazon.Panorama.Model.JobResourceTags[] JobTag { get; set; }
        #endregion
        
        #region Parameter NodeDescription
        /// <summary>
        /// <para>
        /// <para>A description for the node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NodeDescription { get; set; }
        #endregion
        
        #region Parameter NodeName
        /// <summary>
        /// <para>
        /// <para>A name for the node.</para>
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
        public System.String NodeName { get; set; }
        #endregion
        
        #region Parameter OutputPackageName
        /// <summary>
        /// <para>
        /// <para>An output package name for the node.</para>
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
        public System.String OutputPackageName { get; set; }
        #endregion
        
        #region Parameter OutputPackageVersion
        /// <summary>
        /// <para>
        /// <para>An output package version for the node.</para>
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
        public System.String OutputPackageVersion { get; set; }
        #endregion
        
        #region Parameter TemplateParameter
        /// <summary>
        /// <para>
        /// <para>Template parameters for the node.</para>
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
        [Alias("TemplateParameters")]
        public System.Collections.Hashtable TemplateParameter { get; set; }
        #endregion
        
        #region Parameter TemplateType
        /// <summary>
        /// <para>
        /// <para>The type of node.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Panorama.TemplateType")]
        public Amazon.Panorama.TemplateType TemplateType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Panorama.Model.CreateNodeFromTemplateJobResponse).
        /// Specifying the name of a property of type Amazon.Panorama.Model.CreateNodeFromTemplateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutputPackageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PANNodeFromTemplateJob (CreateNodeFromTemplateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Panorama.Model.CreateNodeFromTemplateJobResponse, NewPANNodeFromTemplateJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.JobTag != null)
            {
                context.JobTag = new List<Amazon.Panorama.Model.JobResourceTags>(this.JobTag);
            }
            context.NodeDescription = this.NodeDescription;
            context.NodeName = this.NodeName;
            #if MODULAR
            if (this.NodeName == null && ParameterWasBound(nameof(this.NodeName)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputPackageName = this.OutputPackageName;
            #if MODULAR
            if (this.OutputPackageName == null && ParameterWasBound(nameof(this.OutputPackageName)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputPackageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputPackageVersion = this.OutputPackageVersion;
            #if MODULAR
            if (this.OutputPackageVersion == null && ParameterWasBound(nameof(this.OutputPackageVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputPackageVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TemplateParameter != null)
            {
                context.TemplateParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TemplateParameter.Keys)
                {
                    context.TemplateParameter.Add((String)hashKey, (String)(this.TemplateParameter[hashKey]));
                }
            }
            #if MODULAR
            if (this.TemplateParameter == null && ParameterWasBound(nameof(this.TemplateParameter)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateParameter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateType = this.TemplateType;
            #if MODULAR
            if (this.TemplateType == null && ParameterWasBound(nameof(this.TemplateType)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Panorama.Model.CreateNodeFromTemplateJobRequest();
            
            if (cmdletContext.JobTag != null)
            {
                request.JobTags = cmdletContext.JobTag;
            }
            if (cmdletContext.NodeDescription != null)
            {
                request.NodeDescription = cmdletContext.NodeDescription;
            }
            if (cmdletContext.NodeName != null)
            {
                request.NodeName = cmdletContext.NodeName;
            }
            if (cmdletContext.OutputPackageName != null)
            {
                request.OutputPackageName = cmdletContext.OutputPackageName;
            }
            if (cmdletContext.OutputPackageVersion != null)
            {
                request.OutputPackageVersion = cmdletContext.OutputPackageVersion;
            }
            if (cmdletContext.TemplateParameter != null)
            {
                request.TemplateParameters = cmdletContext.TemplateParameter;
            }
            if (cmdletContext.TemplateType != null)
            {
                request.TemplateType = cmdletContext.TemplateType;
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
        
        private Amazon.Panorama.Model.CreateNodeFromTemplateJobResponse CallAWSServiceOperation(IAmazonPanorama client, Amazon.Panorama.Model.CreateNodeFromTemplateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Panorama", "CreateNodeFromTemplateJob");
            try
            {
                #if DESKTOP
                return client.CreateNodeFromTemplateJob(request);
                #elif CORECLR
                return client.CreateNodeFromTemplateJobAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Panorama.Model.JobResourceTags> JobTag { get; set; }
            public System.String NodeDescription { get; set; }
            public System.String NodeName { get; set; }
            public System.String OutputPackageName { get; set; }
            public System.String OutputPackageVersion { get; set; }
            public Dictionary<System.String, System.String> TemplateParameter { get; set; }
            public Amazon.Panorama.TemplateType TemplateType { get; set; }
            public System.Func<Amazon.Panorama.Model.CreateNodeFromTemplateJobResponse, NewPANNodeFromTemplateJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
