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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Updates the settings for an allow list.
    /// </summary>
    [Cmdlet("Update", "MAC2AllowList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Macie2.Model.UpdateAllowListResponse")]
    [AWSCmdlet("Calls the Amazon Macie 2 UpdateAllowList API operation.", Operation = new[] {"UpdateAllowList"}, SelectReturnType = typeof(Amazon.Macie2.Model.UpdateAllowListResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.UpdateAllowListResponse",
        "This cmdlet returns an Amazon.Macie2.Model.UpdateAllowListResponse object containing multiple properties."
    )]
    public partial class UpdateMAC2AllowListCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3WordsList_BucketName
        /// <summary>
        /// <para>
        /// <para>The full name of the S3 bucket that contains the object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_S3WordsList_BucketName")]
        public System.String S3WordsList_BucketName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A custom description of the allow list. The description can contain as many as 512
        /// characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Amazon Macie resource that the request applies to.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A custom name for the allow list. The name can contain as many as 128 characters.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3WordsList_ObjectKey
        /// <summary>
        /// <para>
        /// <para>The full name (key) of the object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_S3WordsList_ObjectKey")]
        public System.String S3WordsList_ObjectKey { get; set; }
        #endregion
        
        #region Parameter Criteria_Regex
        /// <summary>
        /// <para>
        /// <para>The regular expression (<i>regex</i>) that defines the text pattern to ignore. The
        /// expression can contain as many as 512 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Criteria_Regex { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.UpdateAllowListResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.UpdateAllowListResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MAC2AllowList (UpdateAllowList)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.UpdateAllowListResponse, UpdateMAC2AllowListCmdlet>(Select) ??
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
            context.Criteria_Regex = this.Criteria_Regex;
            context.S3WordsList_BucketName = this.S3WordsList_BucketName;
            context.S3WordsList_ObjectKey = this.S3WordsList_ObjectKey;
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Macie2.Model.UpdateAllowListRequest();
            
            
             // populate Criteria
            var requestCriteriaIsNull = true;
            request.Criteria = new Amazon.Macie2.Model.AllowListCriteria();
            System.String requestCriteria_criteria_Regex = null;
            if (cmdletContext.Criteria_Regex != null)
            {
                requestCriteria_criteria_Regex = cmdletContext.Criteria_Regex;
            }
            if (requestCriteria_criteria_Regex != null)
            {
                request.Criteria.Regex = requestCriteria_criteria_Regex;
                requestCriteriaIsNull = false;
            }
            Amazon.Macie2.Model.S3WordsList requestCriteria_criteria_S3WordsList = null;
            
             // populate S3WordsList
            var requestCriteria_criteria_S3WordsListIsNull = true;
            requestCriteria_criteria_S3WordsList = new Amazon.Macie2.Model.S3WordsList();
            System.String requestCriteria_criteria_S3WordsList_s3WordsList_BucketName = null;
            if (cmdletContext.S3WordsList_BucketName != null)
            {
                requestCriteria_criteria_S3WordsList_s3WordsList_BucketName = cmdletContext.S3WordsList_BucketName;
            }
            if (requestCriteria_criteria_S3WordsList_s3WordsList_BucketName != null)
            {
                requestCriteria_criteria_S3WordsList.BucketName = requestCriteria_criteria_S3WordsList_s3WordsList_BucketName;
                requestCriteria_criteria_S3WordsListIsNull = false;
            }
            System.String requestCriteria_criteria_S3WordsList_s3WordsList_ObjectKey = null;
            if (cmdletContext.S3WordsList_ObjectKey != null)
            {
                requestCriteria_criteria_S3WordsList_s3WordsList_ObjectKey = cmdletContext.S3WordsList_ObjectKey;
            }
            if (requestCriteria_criteria_S3WordsList_s3WordsList_ObjectKey != null)
            {
                requestCriteria_criteria_S3WordsList.ObjectKey = requestCriteria_criteria_S3WordsList_s3WordsList_ObjectKey;
                requestCriteria_criteria_S3WordsListIsNull = false;
            }
             // determine if requestCriteria_criteria_S3WordsList should be set to null
            if (requestCriteria_criteria_S3WordsListIsNull)
            {
                requestCriteria_criteria_S3WordsList = null;
            }
            if (requestCriteria_criteria_S3WordsList != null)
            {
                request.Criteria.S3WordsList = requestCriteria_criteria_S3WordsList;
                requestCriteriaIsNull = false;
            }
             // determine if request.Criteria should be set to null
            if (requestCriteriaIsNull)
            {
                request.Criteria = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Macie2.Model.UpdateAllowListResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.UpdateAllowListRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "UpdateAllowList");
            try
            {
                #if DESKTOP
                return client.UpdateAllowList(request);
                #elif CORECLR
                return client.UpdateAllowListAsync(request).GetAwaiter().GetResult();
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
            public System.String Criteria_Regex { get; set; }
            public System.String S3WordsList_BucketName { get; set; }
            public System.String S3WordsList_ObjectKey { get; set; }
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.Macie2.Model.UpdateAllowListResponse, UpdateMAC2AllowListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
