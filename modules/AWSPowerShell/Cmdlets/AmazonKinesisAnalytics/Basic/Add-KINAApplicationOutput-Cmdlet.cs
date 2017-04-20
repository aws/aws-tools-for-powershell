/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.KinesisAnalytics;
using Amazon.KinesisAnalytics.Model;

namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// Adds an external destination to your Amazon Kinesis Analytics application.
    /// 
    ///  
    /// <para>
    /// If you want Amazon Kinesis Analytics to deliver data from an in-application stream
    /// within your application to an external destination (such as an Amazon Kinesis stream
    /// or a Firehose delivery stream), you add the relevant configuration to your application
    /// using this operation. You can configure one or more outputs for your application.
    /// Each output configuration maps an in-application stream and an external destination.
    /// </para><para>
    ///  You can use one of the output configurations to deliver data from your in-application
    /// error stream to an external destination so that you can analyze the errors. For conceptual
    /// information, see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works-output.html">Understanding
    /// Application Output (Destination)</a>. 
    /// </para><para>
    ///  Note that any configuration update, including adding a streaming source using this
    /// operation, results in a new version of the application. You can use the <a>DescribeApplication</a>
    /// operation to find the current application version.
    /// </para><para>
    /// For the limits on the number of application inputs and outputs you can configure,
    /// see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/limits.html">Limits</a>.
    /// </para><para>
    /// This operation requires permissions to perform the <code>kinesisanalytics:AddApplicationOutput</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "KINAApplicationOutput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the AddApplicationOutput operation against Amazon Kinesis Analytics.", Operation = new[] {"AddApplicationOutput"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ApplicationName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KinesisAnalytics.Model.AddApplicationOutputResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddKINAApplicationOutputCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of the application to which you want to add the output configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>Version of the application to which you want add the output configuration. You can
        /// use the <a>DescribeApplication</a> operation to get the current application version.
        /// If the version specified is not the current version, the <code>ConcurrentModificationException</code>
        /// is returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64 CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter Output_Name
        /// <summary>
        /// <para>
        /// <para>Name of the in-application stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Output_Name { get; set; }
        #endregion
        
        #region Parameter DestinationSchema_RecordFormatType
        /// <summary>
        /// <para>
        /// <para>Specifies the format of the records on the output stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Output_DestinationSchema_RecordFormatType")]
        [AWSConstantClassSource("Amazon.KinesisAnalytics.RecordFormatType")]
        public Amazon.KinesisAnalytics.RecordFormatType DestinationSchema_RecordFormatType { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseOutput_ResourceARN
        /// <summary>
        /// <para>
        /// <para>ARN of the destination Amazon Kinesis Firehose delivery stream to write to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Output_KinesisFirehoseOutput_ResourceARN")]
        public System.String KinesisFirehoseOutput_ResourceARN { get; set; }
        #endregion
        
        #region Parameter KinesisStreamsOutput_ResourceARN
        /// <summary>
        /// <para>
        /// <para>ARN of the destination Amazon Kinesis stream to write to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Output_KinesisStreamsOutput_ResourceARN")]
        public System.String KinesisStreamsOutput_ResourceARN { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseOutput_RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to write to the destination
        /// stream on your behalf. You need to grant the necessary permissions to this role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Output_KinesisFirehoseOutput_RoleARN")]
        public System.String KinesisFirehoseOutput_RoleARN { get; set; }
        #endregion
        
        #region Parameter KinesisStreamsOutput_RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to write to the destination
        /// stream on your behalf. You need to grant the necessary permissions to this role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Output_KinesisStreamsOutput_RoleARN")]
        public System.String KinesisStreamsOutput_RoleARN { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ApplicationName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINAApplicationOutput (AddApplicationOutput)"))
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
            
            context.ApplicationName = this.ApplicationName;
            if (ParameterWasBound("CurrentApplicationVersionId"))
                context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            context.Output_DestinationSchema_RecordFormatType = this.DestinationSchema_RecordFormatType;
            context.Output_KinesisFirehoseOutput_ResourceARN = this.KinesisFirehoseOutput_ResourceARN;
            context.Output_KinesisFirehoseOutput_RoleARN = this.KinesisFirehoseOutput_RoleARN;
            context.Output_KinesisStreamsOutput_ResourceARN = this.KinesisStreamsOutput_ResourceARN;
            context.Output_KinesisStreamsOutput_RoleARN = this.KinesisStreamsOutput_RoleARN;
            context.Output_Name = this.Output_Name;
            
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
            var request = new Amazon.KinesisAnalytics.Model.AddApplicationOutputRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
            }
            
             // populate Output
            bool requestOutputIsNull = true;
            request.Output = new Amazon.KinesisAnalytics.Model.Output();
            System.String requestOutput_output_Name = null;
            if (cmdletContext.Output_Name != null)
            {
                requestOutput_output_Name = cmdletContext.Output_Name;
            }
            if (requestOutput_output_Name != null)
            {
                request.Output.Name = requestOutput_output_Name;
                requestOutputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.DestinationSchema requestOutput_output_DestinationSchema = null;
            
             // populate DestinationSchema
            bool requestOutput_output_DestinationSchemaIsNull = true;
            requestOutput_output_DestinationSchema = new Amazon.KinesisAnalytics.Model.DestinationSchema();
            Amazon.KinesisAnalytics.RecordFormatType requestOutput_output_DestinationSchema_destinationSchema_RecordFormatType = null;
            if (cmdletContext.Output_DestinationSchema_RecordFormatType != null)
            {
                requestOutput_output_DestinationSchema_destinationSchema_RecordFormatType = cmdletContext.Output_DestinationSchema_RecordFormatType;
            }
            if (requestOutput_output_DestinationSchema_destinationSchema_RecordFormatType != null)
            {
                requestOutput_output_DestinationSchema.RecordFormatType = requestOutput_output_DestinationSchema_destinationSchema_RecordFormatType;
                requestOutput_output_DestinationSchemaIsNull = false;
            }
             // determine if requestOutput_output_DestinationSchema should be set to null
            if (requestOutput_output_DestinationSchemaIsNull)
            {
                requestOutput_output_DestinationSchema = null;
            }
            if (requestOutput_output_DestinationSchema != null)
            {
                request.Output.DestinationSchema = requestOutput_output_DestinationSchema;
                requestOutputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.KinesisFirehoseOutput requestOutput_output_KinesisFirehoseOutput = null;
            
             // populate KinesisFirehoseOutput
            bool requestOutput_output_KinesisFirehoseOutputIsNull = true;
            requestOutput_output_KinesisFirehoseOutput = new Amazon.KinesisAnalytics.Model.KinesisFirehoseOutput();
            System.String requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_ResourceARN = null;
            if (cmdletContext.Output_KinesisFirehoseOutput_ResourceARN != null)
            {
                requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_ResourceARN = cmdletContext.Output_KinesisFirehoseOutput_ResourceARN;
            }
            if (requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_ResourceARN != null)
            {
                requestOutput_output_KinesisFirehoseOutput.ResourceARN = requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_ResourceARN;
                requestOutput_output_KinesisFirehoseOutputIsNull = false;
            }
            System.String requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_RoleARN = null;
            if (cmdletContext.Output_KinesisFirehoseOutput_RoleARN != null)
            {
                requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_RoleARN = cmdletContext.Output_KinesisFirehoseOutput_RoleARN;
            }
            if (requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_RoleARN != null)
            {
                requestOutput_output_KinesisFirehoseOutput.RoleARN = requestOutput_output_KinesisFirehoseOutput_kinesisFirehoseOutput_RoleARN;
                requestOutput_output_KinesisFirehoseOutputIsNull = false;
            }
             // determine if requestOutput_output_KinesisFirehoseOutput should be set to null
            if (requestOutput_output_KinesisFirehoseOutputIsNull)
            {
                requestOutput_output_KinesisFirehoseOutput = null;
            }
            if (requestOutput_output_KinesisFirehoseOutput != null)
            {
                request.Output.KinesisFirehoseOutput = requestOutput_output_KinesisFirehoseOutput;
                requestOutputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.KinesisStreamsOutput requestOutput_output_KinesisStreamsOutput = null;
            
             // populate KinesisStreamsOutput
            bool requestOutput_output_KinesisStreamsOutputIsNull = true;
            requestOutput_output_KinesisStreamsOutput = new Amazon.KinesisAnalytics.Model.KinesisStreamsOutput();
            System.String requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_ResourceARN = null;
            if (cmdletContext.Output_KinesisStreamsOutput_ResourceARN != null)
            {
                requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_ResourceARN = cmdletContext.Output_KinesisStreamsOutput_ResourceARN;
            }
            if (requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_ResourceARN != null)
            {
                requestOutput_output_KinesisStreamsOutput.ResourceARN = requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_ResourceARN;
                requestOutput_output_KinesisStreamsOutputIsNull = false;
            }
            System.String requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_RoleARN = null;
            if (cmdletContext.Output_KinesisStreamsOutput_RoleARN != null)
            {
                requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_RoleARN = cmdletContext.Output_KinesisStreamsOutput_RoleARN;
            }
            if (requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_RoleARN != null)
            {
                requestOutput_output_KinesisStreamsOutput.RoleARN = requestOutput_output_KinesisStreamsOutput_kinesisStreamsOutput_RoleARN;
                requestOutput_output_KinesisStreamsOutputIsNull = false;
            }
             // determine if requestOutput_output_KinesisStreamsOutput should be set to null
            if (requestOutput_output_KinesisStreamsOutputIsNull)
            {
                requestOutput_output_KinesisStreamsOutput = null;
            }
            if (requestOutput_output_KinesisStreamsOutput != null)
            {
                request.Output.KinesisStreamsOutput = requestOutput_output_KinesisStreamsOutput;
                requestOutputIsNull = false;
            }
             // determine if request.Output should be set to null
            if (requestOutputIsNull)
            {
                request.Output = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ApplicationName;
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
        
        private Amazon.KinesisAnalytics.Model.AddApplicationOutputResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.AddApplicationOutputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "AddApplicationOutput");
            #if DESKTOP
            return client.AddApplicationOutput(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AddApplicationOutputAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationName { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public Amazon.KinesisAnalytics.RecordFormatType Output_DestinationSchema_RecordFormatType { get; set; }
            public System.String Output_KinesisFirehoseOutput_ResourceARN { get; set; }
            public System.String Output_KinesisFirehoseOutput_RoleARN { get; set; }
            public System.String Output_KinesisStreamsOutput_ResourceARN { get; set; }
            public System.String Output_KinesisStreamsOutput_RoleARN { get; set; }
            public System.String Output_Name { get; set; }
        }
        
    }
}
