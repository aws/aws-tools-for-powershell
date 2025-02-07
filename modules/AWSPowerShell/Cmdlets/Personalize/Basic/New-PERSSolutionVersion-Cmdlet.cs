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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Trains or retrains an active solution in a Custom dataset group. A solution is created
    /// using the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_CreateSolution.html">CreateSolution</a>
    /// operation and must be in the ACTIVE state before calling <c>CreateSolutionVersion</c>.
    /// A new version of the solution is created every time you call this operation.
    /// 
    ///  
    /// <para><b>Status</b></para><para>
    /// A solution version can be in one of the following states:
    /// </para><ul><li><para>
    /// CREATE PENDING
    /// </para></li><li><para>
    /// CREATE IN_PROGRESS
    /// </para></li><li><para>
    /// ACTIVE
    /// </para></li><li><para>
    /// CREATE FAILED
    /// </para></li><li><para>
    /// CREATE STOPPING
    /// </para></li><li><para>
    /// CREATE STOPPED
    /// </para></li></ul><para>
    /// To get the status of the version, call <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeSolutionVersion.html">DescribeSolutionVersion</a>.
    /// Wait until the status shows as ACTIVE before calling <c>CreateCampaign</c>.
    /// </para><para>
    /// If the status shows as CREATE FAILED, the response includes a <c>failureReason</c>
    /// key, which describes why the job failed.
    /// </para><para><b>Related APIs</b></para><ul><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_ListSolutionVersions.html">ListSolutionVersions</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeSolutionVersion.html">DescribeSolutionVersion</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_ListSolutions.html">ListSolutions</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_CreateSolution.html">CreateSolution</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeSolution.html">DescribeSolution</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DeleteSolution.html">DeleteSolution</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PERSSolutionVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize CreateSolutionVersion API operation.", Operation = new[] {"CreateSolutionVersion"}, SelectReturnType = typeof(Amazon.Personalize.Model.CreateSolutionVersionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.CreateSolutionVersionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.CreateSolutionVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPERSSolutionVersionCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the solution version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SolutionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the solution containing the training configuration
        /// information.</para>
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
        public System.String SolutionArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/personalize/latest/dg/tagging-resources.html">tags</a>
        /// to apply to the solution version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Personalize.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrainingMode
        /// <summary>
        /// <para>
        /// <para>The scope of training to be performed when creating the solution version. The default
        /// is <c>FULL</c>. This creates a completely new model based on the entirety of the training
        /// data from the datasets in your dataset group. </para><para>If you use <a href="https://docs.aws.amazon.com/personalize/latest/dg/native-recipe-new-item-USER_PERSONALIZATION.html">User-Personalization</a>,
        /// you can specify a training mode of <c>UPDATE</c>. This updates the model to consider
        /// new items for recommendations. It is not a full retraining. You should still complete
        /// a full retraining weekly. If you specify <c>UPDATE</c>, Amazon Personalize will stop
        /// automatic updates for the solution version. To resume updates, create a new solution
        /// with training mode set to <c>FULL</c> and deploy it in a campaign. For more information
        /// about automatic updates, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/use-case-recipe-features.html#maintaining-with-automatic-updates">Automatic
        /// updates</a>. </para><para>The <c>UPDATE</c> option can only be used when you already have an active solution
        /// version created from the input solution using the <c>FULL</c> option and the input
        /// solution was trained with the <a href="https://docs.aws.amazon.com/personalize/latest/dg/native-recipe-new-item-USER_PERSONALIZATION.html">User-Personalization</a>
        /// recipe or the legacy <a href="https://docs.aws.amazon.com/personalize/latest/dg/native-recipe-hrnn-coldstart.html">HRNN-Coldstart</a>
        /// recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Personalize.TrainingMode")]
        public Amazon.Personalize.TrainingMode TrainingMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SolutionVersionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.CreateSolutionVersionResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.CreateSolutionVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SolutionVersionArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SolutionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PERSSolutionVersion (CreateSolutionVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.CreateSolutionVersionResponse, NewPERSSolutionVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            context.SolutionArn = this.SolutionArn;
            #if MODULAR
            if (this.SolutionArn == null && ParameterWasBound(nameof(this.SolutionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SolutionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Personalize.Model.Tag>(this.Tag);
            }
            context.TrainingMode = this.TrainingMode;
            
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
            var request = new Amazon.Personalize.Model.CreateSolutionVersionRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SolutionArn != null)
            {
                request.SolutionArn = cmdletContext.SolutionArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrainingMode != null)
            {
                request.TrainingMode = cmdletContext.TrainingMode;
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
        
        private Amazon.Personalize.Model.CreateSolutionVersionResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.CreateSolutionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "CreateSolutionVersion");
            try
            {
                #if DESKTOP
                return client.CreateSolutionVersion(request);
                #elif CORECLR
                return client.CreateSolutionVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String SolutionArn { get; set; }
            public List<Amazon.Personalize.Model.Tag> Tag { get; set; }
            public Amazon.Personalize.TrainingMode TrainingMode { get; set; }
            public System.Func<Amazon.Personalize.Model.CreateSolutionVersionResponse, NewPERSSolutionVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SolutionVersionArn;
        }
        
    }
}
